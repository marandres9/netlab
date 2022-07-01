import {
    Component,
    EventEmitter,
    Input,
    Output,
    ViewChild,
} from '@angular/core'
import { MatTable } from '@angular/material/table'
import { Shipper } from '../models/Shipper'

@Component({
    selector: 'app-shipper-list',
    templateUrl: './shipper-list.component.html',
    styleUrls: ['./shipper-list.component.scss'],
})
export class ShipperListComponent {
    @Input() shipperList: Shipper[] = []

    @Output() btnReloadEvent = new EventEmitter()
    @Output() btnDetailsEvent = new EventEmitter<number>()
    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()
    @Output() btnAddEvent = new EventEmitter()

    @ViewChild(MatTable) table!: MatTable<Shipper>

    displayedColumns = ['CompanyName', 'ItemActions', 'TableActions']

    constructor() {}

    // Metodos para emitir eventos al componente padre cada vez que se clickea un
    // boton de la tabla
    onBtnAdd() {
        this.btnAddEvent.emit()
    }

    onBtnReload() {
        this.btnReloadEvent.emit()
    }
    
    onBtnEdit(id: number) {
        this.btnEditEvent.emit(id)
    }

    onRowClick(id: number) {
        this.btnDetailsEvent.emit(id)
    }

    onBtnDelete(id: number) {
        this.btnDeleteEvent.emit(id)
    }
}
