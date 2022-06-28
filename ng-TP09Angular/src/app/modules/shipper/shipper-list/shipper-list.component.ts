import {
    Component,
    EventEmitter,
    Input,
    OnChanges,
    OnInit,
    Output,
    SimpleChanges,
    ViewChild,
} from '@angular/core'
import { MatTable, MatTableDataSource } from '@angular/material/table'
import { Shipper } from '../models/Shipper'
import { FormListenerService } from '../services/form-listener.service'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent implements OnInit {
    @Input() shippers: Shipper[] = []

    @Output() detailsEvent = new EventEmitter<number>()

    @ViewChild(MatTable) table!: MatTable<Shipper>

    displayedColumns = ['CompanyName', 'Actions']

    constructor(private formListner: FormListenerService<Shipper>) {}

    ngOnInit(): void {        
        this.formListner.formValue$.subscribe((shipper) => {            
            this.shippers.push(shipper)
            this.table.renderRows()
        })
    }

    onBtnDetails(id: number) {
        this.detailsEvent.emit(id)
    }
}
