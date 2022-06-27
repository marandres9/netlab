import { Component, OnInit } from '@angular/core'
import { FormControl, FormGroup } from '@angular/forms'
import { Router } from '@angular/router'
import { HttpService } from 'src/app/core/service/http.service'

@Component({
    selector: 'app-shipper-form',
    templateUrl: './shipper-form.component.html',
    styleUrls: ['./shipper-form.component.scss'],
})
export class ShipperFormComponent implements OnInit {
    shipperForm: FormGroup = new FormGroup({
      'ShipperID': new FormControl(),
      'CompanyName': new FormControl(),
      'Phone': new FormControl()
    })

    constructor(private http: HttpService, private router: Router) {}

    ngOnInit(): void {}

    onSubmit() {
      this.http.postShipper(this.shipperForm.value).subscribe(() => this.router.navigate(['/crud/shippers']))
    }
}
