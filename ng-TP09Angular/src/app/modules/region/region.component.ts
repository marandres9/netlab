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
    }

    getDetails(id: number) {
        this.http.getDetailedRegion(id).subscribe((region) => {
            this.detailedRegion = region
        })
    }

    onAdd(newRegion: Region) {
        this.http.postRegion(newRegion).subscribe(() => {
            this.getList()
        })
    }

    onEdit(editedRegion: Region) {
        this.http.putRegion(editedRegion).subscribe((edited) => {
            this.getList()
            this.updateDetailedRegion(edited.RegionID, false)
        })
    }

    onDelete(id: number) {
        this.http.deleteRegion(id).subscribe((id) => {
            this.getList()
            this.updateDetailedRegion(id, true)
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

    onBtnEdit(id: number) {
        // si el objeto ya se está mostrando invierte el estado del panel
        if (this.editingRegion?.RegionID === id) {
            this.editingForm.togglePanel()
        }
        // sino busca el objeto seleccionado y abre el panel
        else {
            this.editingRegion = this.findRegion(id)
            if (this.editingRegion) this.editingForm.expandPanel()
        }
    }

    findRegion(id: number) {
        return this.regionList.find((region) => region.RegionID === id) ?? null
    }

    updateDetailedRegion(id: number, deleted: boolean) {
        if (id === this.detailedRegion?.RegionID) {
            if (deleted) {
                this.detailedRegion = null
            } else {
              this.getDetails(id)
            }
        }
    }
}
