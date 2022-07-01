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
import { ShipperDetails } from '../models/ShipperDetails'

@Component({
    selector: 'app-shipper-details',
    templateUrl: './shipper-details.component.html',
    styleUrls: ['./shipper-details.component.scss'],
})
export class ShipperDetailsComponent implements OnChanges, AfterViewInit {
    @Input() detailedShipper!: ShipperDetails | null

    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()

    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    isExpanded = false

    constructor() {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.detailedShipper) {
            this.panel.open()
        } else if(!changes['detailedShipper'].isFirstChange()) {
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

    onBtnEdit(id: number) {
        this.btnEditEvent.emit(id)
    }
    onBtnDelete(id: number) {
        this.btnDeleteEvent.emit(id)
    }
}
