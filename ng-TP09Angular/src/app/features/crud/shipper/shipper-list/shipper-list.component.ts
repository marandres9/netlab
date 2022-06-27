import { Component, OnInit } from '@angular/core'
import { Shipper } from 'src/app/shared/models/Shipper'
import { HttpService } from 'src/app/core/service/http.service'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent implements OnInit {
    shippers: Shipper[] = []

    constructor(private http: HttpService) {}

    ngOnInit(): void {
        this.getAll()
    }

    getAll() {
        this.http
            .getAllShippers()
            .subscribe((shippers) => (this.shippers = shippers))
    }

    getDetails(id: number) {

    }

    delete(id: number) {
        
    }
}
