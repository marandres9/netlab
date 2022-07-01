import { Component, OnInit, ViewChild } from '@angular/core'
import { MatDialog } from '@angular/material/dialog'
import { HttpService } from 'src/app/core/http/http.service'
import { DeleteDialogComponent } from 'src/app/shared/components/delete-dialog/delete-dialog.component'
import { ErrorDialogComponent } from 'src/app/shared/components/error-dialog/error-dialog.component'
import { Region } from './model/Region'
import { RegionDetails } from './model/RegionDetails'
import { RegionDetailsComponent } from './region-details/region-details.component'
import { RegionFormComponent } from './region-form/region-form.component'

@Component({
    selector: 'app-region',
    templateUrl: './region.component.html',
    styleUrls: ['./region.component.scss'],
})
export class RegionComponent implements OnInit {
    regionList: Region[] = []
    // Objectos que se pasan a los componentes de edición y detalles:
    detailedRegion: RegionDetails | null = null
    invalidNewRegion: Region | null = null
    editingRegion: Region | null = null

    
    // Obtiene los ExtensionPanels hijos para poder mostrarlos o esconderlos cuando se 
    // se reciben los eventos apropiados.
    @ViewChild('addingForm') addingForm!: RegionFormComponent
    @ViewChild(RegionDetailsComponent) detailsComponent!: RegionDetailsComponent
    @ViewChild('editingForm') editingForm!: RegionFormComponent

    constructor(private http: HttpService, public matDialog: MatDialog) {}

    ngOnInit(): void {
        this.getList()
    }

    getList() {
        this.http.getAllRegions().subscribe((regions) => (this.regionList = regions))
        this.updateDetailedRegion()
    }

    /** Obtiene los detalles de un objeto y los muestra en el panel hijo.
     * 
     * Si el objeto no se encuentra en la BBDD, muestra un error al usuario y actualiza 
     * la lista local.
     */
    getDetails(id: number) {
        this.http.getDetailedRegion(id).subscribe({
            next: (region) => {
                this.detailedRegion = region
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.detailedRegion = null
                this.getList()
            },
        })
    }
    /** Hace lo mismo que getDetails() pero no abre un dialogo de error en caso de
     * que el objeto no se encuentre.
     * 
     * Es llamado indirectamente por otros métodos que modifiquen la base de 
     * datos en caso de que se intente acceder a un objeto que no existe (porque ya fue
     * eliminado por otro usuario o porque no se encuentra el ID). 
     * 
     * No muestra el dialogo de error porque los otros métodos ya muestran su propio dialogo.
     */
    getDetailsNoErrorDialog(id: number) {
        this.http.getDetailedRegion(id).subscribe({
            next: (region) => {
                this.detailedRegion = region
            },
            error: (error) => {
                this.detailedRegion = null
                this.getList()
            },
        })
    }

    /** Hace una llamada POST con el nuevo objeto. Si no hay errores vuelve a pedir 
     * la lista actualizada, sino muestra el error en un dialogo. */
    onAdd(newRegion: Region) {
        this.http.postRegion(newRegion).subscribe({
            next: () => {
                this.getList()
                this.invalidNewRegion = null
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.invalidNewRegion = newRegion
            },
        })
    }

    /** Hace una llamada PUT con el objeto editado. Si no hay errores vuelve a pedir
     * la lista actualizada, sino muestra un mensaje de error.
     * 
     * En ambos casos también se actualiza el objeto mostrado en el panel de detalles.
     */
    onEdit(editedRegion: Region) {
        this.http.putRegion(editedRegion).subscribe({
            next: () => {
                this.getList()
                this.updateDetailedRegion()
            },
            error: (error) => {
                this.openErrorDialog(error.message)
                this.getList()
                this.updateDetailedRegion()
            },
        })
    }

    /** Hace una llamada DELETE con el ID del objeto a eliminar. Si no hay errores
     *  vuelve a pedir la lista actualizada, sino muestra un mensaje de error.
     * 
     * En ambos casos también se actualiza el objeto mostrado en el panel de detalles.
     */
    onDelete(id: number) {
        this.openDeleteConfirmDialog(this.findRegion(id)!).subscribe((result) => {
            if (result) {
                this.http.deleteRegion(id).subscribe({
                    next: (deletedID) => {
                        this.getList()
                        this.updateDetailedRegion()
                    },
                    error: (error) => {
                        this.openErrorDialog(error.message)
                        this.getList()
                        this.updateDetailedRegion()
                    },
                })
            }
        })
    }

    /** Pide los detalles del objeto al servidor. Si dicho objeto ya se está mostrando
     * en el panel de detalles, muestra o esconde el panel.
     */
    onDetails(id: number) {
        if (this.detailedRegion && this.detailedRegion.RegionID === id) {
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

    onBtnEdit(id: number) {
        // si el objeto ya se está mostrando invierte el estado del panel
        if (this.editingRegion?.RegionID === id) {
            this.editingForm.togglePanel()
        } else {
            this.editingRegion = this.findRegion(id)
        }
    }

    findRegion(id: number) {
        return this.regionList.find((region) => region.RegionID === id) ?? null
    }

    /** Actualiza los detalles de un objeto solo si el panel de detalles ya está 
     * mostrando algún objeto.
     * 
     * Utilizado por métodos que modifican la lista y podrían llegar a 
     * modificar/eliminar el objeto mostrado en el panel de detalles. */
    updateDetailedRegion() {
        if (this.detailedRegion) {
            this.getDetailsNoErrorDialog(this.detailedRegion.RegionID)
        }
    }

    /** Abre un dialogo para confirmar la eliminaciòn de un objeto. 
     * 
     * Devuelve un observable con la desición del usuario. */
    openDeleteConfirmDialog(region: Region) {
        const dialogRef = this.matDialog.open(DeleteDialogComponent, {
            width: '50em',
            data: { id: region.RegionID, name: region.RegionDescription, type: 'region' },
        })

        return dialogRef.afterClosed()
    }

    /** Abre un dialogo con un mensaje de error. */
    openErrorDialog(msg: string) {
        const dialogRef = this.matDialog.open(ErrorDialogComponent, {
            width: '50em',
            data: { msg: msg },
        })
    }
}
