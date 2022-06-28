import {
    Component,
    EventEmitter,
    OnInit,
    Output,
    ViewChild,
} from '@angular/core'
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { MatExpansionPanel } from '@angular/material/expansion'
import { Router } from '@angular/router'
import { HttpService } from 'src/app/core/http/http.service'
import { FormErrorService } from 'src/app/shared/services/form-error.service'
import { Shipper } from '../models/Shipper'
import { FormListenerService } from '../services/form-listener.service'

@Component({
    selector: 'app-shipper-form',
    templateUrl: './shipper-form.component.html',
    styleUrls: ['./shipper-form.component.scss'],
})
export class ShipperFormComponent implements OnInit {
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    shipperForm: FormGroup = new FormGroup({
        CompanyName: new FormControl('', [
            Validators.required,
            Validators.maxLength(40),
        ]),
        Phone: new FormControl('', Validators.maxLength(24)),
    })

    constructor(
        private formError: FormErrorService,
        private formListener: FormListenerService<Shipper>
    ) {}

    ngOnInit(): void {}

    togglePanel() {
        this.panel.toggle()
    }

    cancel() {
        this.togglePanel()
    }

    onSubmit() {
        if(this.shipperForm.valid)
            this.formListener.setFormValue(this.shipperForm.value)
    }

    get CompanyName() {
        return this.shipperForm.get('CompanyName') as FormControl
    }
    get Phone() {
        return this.shipperForm.get('Phone') as FormControl
    }

    get CompanyNameErrors() {
        if (this.CompanyName.errors?.['required']) {
            return this.formError.requiredMsg()
        } else if (this.CompanyName.errors?.['maxlength']) {
            return this.formError.MaxLengthMsg(40)
        } else {
            return ''
        }
    }
    get PhoneErrors() {
        if (this.Phone.errors?.['maxlength']) {
            return this.formError.MaxLengthMsg(24)
        } else {
            return ''
        }
    }
}
