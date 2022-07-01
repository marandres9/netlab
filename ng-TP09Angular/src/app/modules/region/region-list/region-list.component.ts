import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { Region } from '../model/Region'

@Component({
    selector: 'app-region-list',
    templateUrl: './region-list.component.html',
    styleUrls: ['./region-list.component.scss'],
})
export class RegionListComponent {
    @Input() regionList: Region[] = []
    
    @Output() btnReloadEvent = new EventEmitter()
    @Output() btnDetailsEvent = new EventEmitter<number>()
    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()
    @Output() btnAddEvent = new EventEmitter()

    displayedColumns = ['RegionID', 'RegionDescription', 'ItemActions', 'TableActions']

    constructor() {}

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
        console.log('emit')

        this.btnDetailsEvent.emit(id)
    }

    onBtnDelete(id: number) {
        this.btnDeleteEvent.emit(id)
    }
}
