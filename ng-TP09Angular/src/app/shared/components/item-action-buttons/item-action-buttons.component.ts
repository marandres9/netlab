import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'

@Component({
    selector: 'app-item-action-buttons',
    templateUrl: './item-action-buttons.component.html',
    styleUrls: ['./item-action-buttons.component.scss'],
})
export class ItemActionButtonsComponent implements OnInit {
    @Input() itemID!: number

    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()

    constructor() {}

    ngOnInit(): void {}

    onBtnEdit(id: number) {
        this.btnEditEvent.emit(id)
    }
    onBtnDelete(id: number) {
        this.btnDeleteEvent.emit(id)
    }
}
