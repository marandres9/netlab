import { Component, OnInit, ViewChild } from '@angular/core'
import { HttpService } from 'src/app/core/http/http.service'
import { Region, RegionDetails } from './model/Region'
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

    constructor(private http: HttpService) {}

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
                console.log(error.message)
                this.detailedRegion = null
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
                console.log(error.message)
                this.invalidNewRegion = newRegion
            },
        })
    }

    onEdit(region: Region) {
        this.http.putRegion(region).subscribe({
            next: () => {
                this.getList()
                this.updateDetailedRegion()
            },
            error: (error) => {
                console.log(error.message)
                this.getList()
                this.updateDetailedRegion()
            },
        })
    }

    onDelete(id: number) {
        this.http.deleteRegion(id).subscribe({
            next: (deletedID) => {
                this.getList()
                this.updateDetailedRegion()
            },
            error: (error) => {
                console.log(error.message)
                this.getList()
                this.updateDetailedRegion()
            },
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
        }
        // sino busca el objeto seleccionado y abre el panel
        else {
            this.editingRegion = this.findRegion(id)
        }
    }

    findRegion(id: number) {
        return this.regionList.find((region) => region.RegionID === id) ?? null
    }

    updateDetailedRegion() {
        if (this.detailedRegion) {
            this.getDetails(this.detailedRegion.RegionID)
        }
    }
}
