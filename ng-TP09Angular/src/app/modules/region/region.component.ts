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
    // objectos que se pasan a los componentes de edición y detalles:
    detailedRegion: RegionDetails | null = null
    invalidNewRegion: Region | null = null
    editingRegion: Region | null = null

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

    updateDetailedRegion() {
        if (this.detailedRegion) {
            this.getDetailsNoErrorDialog(this.detailedRegion.RegionID)
        }
    }

    openDeleteConfirmDialog(region: Region) {
        const dialogRef = this.matDialog.open(DeleteDialogComponent, {
            width: '50em',
            data: { id: region.RegionID, name: region.RegionDescription, type: 'region' },
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
