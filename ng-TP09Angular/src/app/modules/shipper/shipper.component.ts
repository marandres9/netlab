import { Component, OnInit, ViewChild } from '@angular/core'
import { MatDialog } from '@angular/material/dialog'
import { HttpService } from 'src/app/core/http/http.service'
import { DeleteDialogComponent } from 'src/app/shared/components/delete-dialog/delete-dialog.component'
import { ErrorDialogComponent } from 'src/app/shared/components/error-dialog/error-dialog.component'
import { Shipper } from './models/Shipper'
import { ShipperDetails } from './models/ShipperDetails'
import { ShipperDetailsComponent } from './shipper-details/shipper-details.component'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'

@Component({
    selector: 'app-shipper',
    templateUrl: './shipper.component.html',
    styleUrls: ['./shipper.component.scss'],
})
export class ShipperComponent implements OnInit {
    shipperList: Shipper[] = []
    // objectos que se pasan a los componentes de edición y detalles:
    detailedShipper: ShipperDetails | null = null
    invalidNewShipper: Shipper | null = null
    editingShipper: Shipper | null = null

    @ViewChild('addingForm') addingForm!: ShipperFormComponent
    @ViewChild(ShipperDetailsComponent) detailsComponent!: ShipperDetailsComponent
    @ViewChild('editingForm') editingForm!: ShipperFormComponent

    constructor(private http: HttpService, public matDialog: MatDialog) {}

    ngOnInit(): void {
        this.getList()
    }

    getList() {
        this.http.getAllShippers().subscribe((shippers) => (this.shipperList = shippers))
        this.updateDetailedShipper()
    }

    getDetails(id: number) {
        this.http.getDetailedShipper(id).subscribe({
            next: (shipper) => {
                this.detailedShipper = shipper
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.detailedShipper = null
                this.getList()
            },
        })
    }

    getDetailsNoErrorDialog(id: number) {
        this.http.getDetailedShipper(id).subscribe({
            next: (shipper) => {
                this.detailedShipper = shipper
            },
            error: (error) => {
                this.detailedShipper = null
                this.getList()
            },
        })
    }

    /** Hace un POST con el nuevo objeto. En este caso se deve volver a pedir la lista ya
     * que no hay forma de saber que ID se le va a asignar al nuevo objeto.
     *
     * Tampoco es necesario usar el servicio tableNotifierService para actualizar la
     * lista ya que al cambiar la referencia de la lista es detectado por el detector de
     * cambios de Angular y la tabla se actualiza sola.
     */
    onAdd(newShipper: Shipper) {
        this.http.postShipper(newShipper).subscribe({
            next: () => {
                this.getList()
                this.invalidNewShipper = null
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.invalidNewShipper = newShipper
            },
        })
    }

    /** Hace un PUT al servidor para actualizar el objecto. También actualiza la
     * lista local y mediante el servicio tableNotifierService avisa al componente
     * shipper-list para que el mismo se actualice.
     * De esta manera no hace falta volver a pedir la lista actualizada al servidor
     */
    onEdit(editedShipper: Shipper) {
        this.http.putShipper(editedShipper).subscribe({
            next: () => {
                this.getList()
                this.updateDetailedShipper()
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.getList()
                this.updateDetailedShipper()
            },
        })
    }

    /** Hace un pedido DELETE al servidor para borrar el objeto. Actualiza la lista local
     * y notifica al componente shipper-list para que el mismo se actualice.
     */
    onDelete(id: number) {
        this.openDeleteConfirmDialog(this.findShipper(id)!).subscribe((result) => {
            if (result) {
                this.http.deleteShipper(id).subscribe({
                    next: (deletedID) => {
                        this.getList()
                        this.updateDetailedShipper()
                    },
                    error: (error) => {
                        this.openErrorDialog(error.message)
                        this.getList()
                        this.updateDetailedShipper()
                    },
                })
            }
        })
    }

    /** Pide los detalles del objecto al servidor o invierte el estado del panel si ya se
     * están mostrando
     */
    onDetails(id: number) {
        if (this.detailedShipper && this.detailedShipper.ShipperID === id) {
            this.detailsComponent.togglePanel()
        } else {
            this.getDetails(id)
        }
    }

    onBtnAdd() {
        this.addingForm.togglePanel()
    }

    onBtnReload() {
        this.getList()
    }

    /**Encuentra el objecto y lo muestra en el formulario de edicion. Abre el panel
     */
    onBtnEdit(id: number) {
        // si el objeto ya se está mostrando invierte el estado del panel
        if (this.editingShipper?.ShipperID === id) {
            this.editingForm.togglePanel()
        } else {
            this.editingShipper = this.findShipper(id)
        }
    }

    /** Busca un objeto con el mismo id en la lista y devuelve el objeto
     * o null si no lo encuentra
     */
    findShipper(id: number) {
        return this.shipperList.find((shipper) => shipper.ShipperID === id) ?? null
    }

    /** Método para usar cuando se modifica algún dato de la tabla (edición/eliminación).
     *
     * Si el ID del objeto actualizado es el mismo que el del objeto detallado, el objeto
     * detallado se actualiza.
     * @param id ID del objeto actualizado
     */
    updateDetailedShipper() {
        if (this.detailedShipper) {
            this.getDetailsNoErrorDialog(this.detailedShipper.ShipperID)
        }
    }

    openDeleteConfirmDialog(shipper: Shipper) {
        const dialogRef = this.matDialog.open(DeleteDialogComponent, {
            width: '50em',
            data: { id: shipper.ShipperID, name: shipper.CompanyName, type: 'shipper' },
        })

        return dialogRef.afterClosed()
    }

    openErrorDialog(msg: string) {
        const dialogRef = this.matDialog.open(ErrorDialogComponent, {
            width: '50em',
            data: { msg: msg },
        })
    }
}
