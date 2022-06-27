import { Component, OnInit } from '@angular/core'
import { Shipper } from 'src/app/shared/models/Shipper'
import { HttpService } from 'src/app/core/service/http.service'

@Component({
    selector: 'app-crud',
    templateUrl: './crud.component.html',
    styleUrls: ['./crud.component.scss'],
})
export class CrudComponent implements OnInit {
    constructor() {}

    ngOnInit(): void {}
}
