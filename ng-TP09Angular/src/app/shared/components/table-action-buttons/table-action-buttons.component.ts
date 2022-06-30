import { Component, EventEmitter, OnInit, Output } from '@angular/core'

@Component({
    selector: 'app-table-action-buttons',
    templateUrl: './table-action-buttons.component.html',
    styleUrls: ['./table-action-buttons.component.scss'],
})
export class TableActionButtonsComponent implements OnInit {
    @Output() btnAddEvent = new EventEmitter()
    @Output() btnReloadEvent = new EventEmitter()

    constructor() {}

    ngOnInit(): void {}

    onBtnAdd() {
        this.btnAddEvent.emit()
    }
    onBtnReload() {
        this.btnReloadEvent.emit()
    }
}
