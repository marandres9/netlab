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
import { TableNotifierService } from '../services/table-notifier.service'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent implements OnInit {
    @Input() shippers: Shipper[] = []

    @Output() detailsEvent = new EventEmitter<number>()
    @Output() editEvent = new EventEmitter<number>()
    @Output() deleteEvent = new EventEmitter<number>()
    @Output() addEvent = new EventEmitter()

    @ViewChild(MatTable) table!: MatTable<Shipper>

    displayedColumns = ['CompanyName', 'Actions', 'Add']

    constructor(private formListner: TableNotifierService) {}

    ngOnInit(): void {
        // Se suscribe al notificador para poder actualizar la tabla
        this.formListner.tableNotifier$.subscribe((updateRows) => {
            if (updateRows) {
                this.table.renderRows()
            }
        })
    }

    // Metodos para emitir eventos al componente padre cada vez que se clickea un
    // boton de la tabla
    onBtnAdd() {
        this.addEvent.emit()
    }

    onBtnEdit(id: number) {
        this.editEvent.emit(id)
    }

    onRowClick(id: number) {
        this.detailsEvent.emit(id)
    }

    onBtnDelete(id: number) {
        this.deleteEvent.emit(id)
    }
}
