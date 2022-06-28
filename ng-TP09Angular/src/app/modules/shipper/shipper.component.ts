import { Component, OnInit, ViewChild } from '@angular/core'
import { HttpService } from 'src/app/core/http/http.service'
import { Shipper, ShipperDetails } from './models/Shipper'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'

@Component({
    selector: 'app-shipper',
    templateUrl: './shipper.component.html',
    styleUrls: ['./shipper.component.scss'],
})
export class ShipperComponent implements OnInit {
    shippers: Shipper[] = []
    detailedShipper!: ShipperDetails

    @ViewChild(ShipperFormComponent) formComponent!: ShipperFormComponent

    constructor(private http: HttpService) {}

    ngOnInit(): void {
      this.getAll()
    }

    getAll() {
        this.http
            .getAllShippers()
            .subscribe((shippers) => (this.shippers = shippers))
    }

    onAdd() {
        this.formComponent.togglePanel()
    }
    
    onDelete(id: number) {}

    onDetails(id: number) {
        this.http.getDetailsShippers(id).subscribe((shipper) => {
            this.detailedShipper = shipper
        })
    }
}
