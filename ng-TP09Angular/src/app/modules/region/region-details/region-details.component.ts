import {
    AfterViewInit,
    Component,
    EventEmitter,
    Input,
    OnChanges,
    OnInit,
    Output,
    SimpleChanges,
    ViewChild,
} from '@angular/core'
import { MatExpansionPanel } from '@angular/material/expansion'
import { RegionDetails } from '../model/Region'

@Component({
    selector: 'app-region-details',
    templateUrl: './region-details.component.html',
    styleUrls: ['./region-details.component.scss'],
})
export class RegionDetailsComponent implements OnInit, OnChanges, AfterViewInit {
    @Input() detailedObject!: RegionDetails | null

    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()
    
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    isExpanded = false

    constructor() {}

    ngOnInit(): void {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.detailedObject) {
            this.panel.open()
        } else if(!changes['detailedObject'].isFirstChange()) {
            this.panel.close()
        }
    }

    ngAfterViewInit(): void {
        this.panel.expandedChange.subscribe((expanded) => {
            this.isExpanded = expanded
        })
    }

    togglePanel() {
        this.panel.toggle()
    }

    onBtnEdit() {
        this.btnEditEvent.emit(this.detailedObject?.RegionID)
    }
    onBtnDelete() {
        this.btnDeleteEvent.emit(this.detailedObject?.RegionID)
    }
}
