import { Component, OnInit, ViewChild } from '@angular/core'
import { HttpService } from 'src/app/core/http/http.service'
import { Shipper, ShipperDetails, shipperList } from './models/Shipper'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'

@Component({
    selector: 'app-shipper',
    templateUrl: './shipper.component.html',
    styleUrls: ['./shipper.component.scss'],
})
export class ShipperComponent implements OnInit {
    shipperList: Shipper[] = []
    detailedShipper!: ShipperDetails

    createdShipper!: Shipper

    @ViewChild(ShipperFormComponent) formComponent!: ShipperFormComponent

    constructor(private http: HttpService) {}

    ngOnInit(): void {
        this.getAll()
    }

    getAll() {
        // http call:
        // this.http
        //     .getAllShippers()
        //     .subscribe((shippers) => (this.shippers = shippers))

        // mock list
        this.shipperList = shipperList
    }

    onBtnAdd() {
        this.formComponent.togglePanel()
    }

    onDelete(id: number) {}

    onDetails(id: number) {
        // http call
        // this.http.getDetailsShippers(id).subscribe((shipper) => {
        //     this.detailedShipper = shipper
        // })
    }
}
