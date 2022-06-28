import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { Shipper } from '../models/Shipper'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent implements OnInit {
    @Input() shippers: Shipper[] = []
    
    @Output() detailsEvent = new EventEmitter<number>()
    
    displayedColumns = ['CompanyName', 'Actions']

    constructor() {}

    ngOnInit(): void {}

    onDetails(id: number) {
        this.detailsEvent.emit(id)
    }
}
