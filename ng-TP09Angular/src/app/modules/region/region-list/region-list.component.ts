import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { Region } from '../model/Region'

@Component({
    selector: 'app-region-list',
    templateUrl: './region-list.component.html',
    styleUrls: ['./region-list.component.scss'],
})
export class RegionListComponent implements OnInit {
    @Input() regionList: Region[] = []

    @Output() detailsEvent = new EventEmitter<number>()
    @Output() editEvent = new EventEmitter<number>()
    @Output() deleteEvent = new EventEmitter<number>()
    @Output() addEvent = new EventEmitter()

    displayedColumns = ['RegionID', 'RegionDescription', 'Actions', 'Add']

    constructor() {}

    ngOnInit(): void {}

    onBtnAdd() {
        this.addEvent.emit()
    }

    onBtnEdit(id: number) {
        this.editEvent.emit(id)
    }

    onRowClick(id: number) {
        console.log('emit')

        this.detailsEvent.emit(id)
    }

    onBtnDelete(id: number) {
        this.deleteEvent.emit(id)
    }
}
