import { Component, OnInit, ViewChild } from '@angular/core'
import { HttpService } from 'src/app/core/http/http.service'
import { Shipper, ShipperDetails } from './models/Shipper'
import { TableNotifierService } from './services/table-notifier.service'
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
    editingShipper: Shipper | null = null

    @ViewChild('addingForm') addingForm!: ShipperFormComponent
    @ViewChild(ShipperDetailsComponent) detailsComponent!: ShipperDetailsComponent
    @ViewChild('editingForm') editingForm!: ShipperFormComponent

    constructor(private http: HttpService, private formListener: TableNotifierService) {}

    ngOnInit(): void {
        this.getList()
    }

    getList() {
        this.http.getAllShippers().subscribe((shippers) => (this.shipperList = shippers))
    }

    /** Hace un POST con el nuevo objeto. En este caso se deve volver a pedir la lista ya
     * que no hay forma de saber que ID se le va a asignar al nuevo objeto.
     *
     * Tampoco es necesario usar el servicio tableNotifierService para actualizar la
     * lista ya que al cambiar la referencia de la lista es detectado por el detector de
     * cambios de Angular y la tabla se actualiza sola.
     */
    onAdd(newShipper: Shipper) {
        this.http.postShipper(newShipper).subscribe((addedShipper) => {
            this.getList()
        })
    }

    /** Hace un PUT al servidor para actualizar el objecto. También actualiza la
     * lista local y mediante el servicio tableNotifierService avisa al componente
     * shipper-list para que el mismo se actualice.
     * De esta manera no hace falta volver a pedir la lista actualizada al servidor
     */
    onEdit(editedShipper: Shipper) {
        this.http.putShipper(editedShipper).subscribe((edited) => {
            let index = this.shipperList.findIndex(
                (shipper) => shipper.ShipperID == edited.ShipperID
            )
            this.shipperList[index] = edited
            this.formListener.notifyTable(true)
            this.updateDetailedShipper(edited.ShipperID)
        })
    }

    /** Hace un pedido DELETE al servidor para borrar el objeto. Actualiza la lista local
     * y notifica al componente shipper-list para que el mismo se actualice.
     */
    onDelete(id: number) {
        this.http.deleteShipper(id).subscribe((deletedID) => {
            let index = this.shipperList.findIndex(
                (shipper) => shipper.ShipperID === deletedID
            )
            this.shipperList.splice(index, 1)
            this.formListener.notifyTable(true)
            this.updateDetailedShipper(id)
        })
    }

    /** Pide los detalles del objecto al servidor o invierte el estado del panel si ya se
     * están mostrando
     */
    onDetails(id: number) {
        if (this.detailedShipper && this.detailedShipper.ShipperID === id) {
            this.detailsComponent.togglePanel()
        } else {
            this.http.getDetailsShippers(id).subscribe((shipper) => {
                this.detailedShipper = shipper
            })
        }
    }

    onBtnAdd() {
        this.addingForm.togglePanel()
    }

    /**Encuentra el objecto y lo muestra en el formulario de edicion. Abre el panel
     */
    onBtnEdit(id: number) {
        // si el objeto ya se está mostrando invierte el estado del panel
        if (this.editingShipper?.ShipperID === id) {
            this.editingForm.togglePanel()
        }
        // sino busca el objeto seleccionado y abre el panel
        else {
            this.editingShipper = this.findShipper(id)
            if (this.editingShipper) this.editingForm.openPanel()
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
    updateDetailedShipper(id: number) {
        if (id === this.detailedShipper?.ShipperID)
            this.detailedShipper = this.findShipper(id)
    }
}
