import {
    Component,
    Input,
    OnChanges,
    OnInit,
    SimpleChanges,
    ViewChild,
} from '@angular/core'
import { MatExpansionPanel } from '@angular/material/expansion'
import { ShipperDetails } from '../models/Shipper'

@Component({
    selector: 'app-shipper-details',
    templateUrl: './shipper-details.component.html',
    styleUrls: ['./shipper-details.component.scss'],
})
export class ShipperDetailsComponent implements OnInit, OnChanges {
    @Input() shipper!: ShipperDetails | null

    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    constructor() {}

    ngOnInit(): void {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.shipper) {
            this.panel.open()
        } 
    }

    togglePanel() {
        this.panel.toggle()
    }
}
