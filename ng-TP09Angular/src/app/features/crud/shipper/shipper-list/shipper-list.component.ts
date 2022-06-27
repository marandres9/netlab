import { Component, OnInit, ViewChild } from '@angular/core'
import { Shipper, ShipperDetails } from 'src/app/features/crud/shipper/shipper-form/models/Shipper'
import { HttpService } from 'src/app/core/http/http.service'
import { MatExpansionPanel } from '@angular/material/expansion'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent implements OnInit {
    shippers: Shipper[] = []
    displayedColumns = ['CompanyName', 'Actions']
    detailedShipper!: ShipperDetails

    constructor(private http: HttpService) {}

    ngOnInit(): void {
        this.getAll()
    }

    getAll() {
        this.http
            .getAllShippers()
            .subscribe((shippers) => (this.shippers = shippers))
    }

    onDelete(id: number) {}

    onDetails(id: number) {
        this.http.getDetailsShippers(id).subscribe((shipper) => {
            this.detailedShipper = shipper            
        })
        // if(!this.isExpanded()){
        //     this.toggleExpansionPanel()
        // }
    }
}
