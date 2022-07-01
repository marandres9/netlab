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
import { RegionDetails } from '../model/RegionDetails'

@Component({
    selector: 'app-region-details',
    templateUrl: './region-details.component.html',
    styleUrls: ['./region-details.component.scss'],
})
export class RegionDetailsComponent implements OnChanges, AfterViewInit {
    @Input() detailedRegion!: RegionDetails | null

    @Output() btnEditEvent = new EventEmitter<number>()
    @Output() btnDeleteEvent = new EventEmitter<number>()
    
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    isExpanded = false

    constructor() {}

    /** Si se recibio un objeto para mostrar abre el panel. Si el objeto a mostrar
     * se seteo a null cierra el panel. */
    ngOnChanges(changes: SimpleChanges): void {
        if (this.detailedRegion) {
            this.panel.open()
        } else if(!changes['detailedRegion'].isFirstChange()) {
            this.panel.close()
        }
    }

    /** Mediante la prop. 'isExpanded' se notifia a la vista para mostrar (o no)
     * la descripción del panel. */
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
