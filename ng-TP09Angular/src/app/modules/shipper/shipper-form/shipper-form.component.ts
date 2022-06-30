// whitespace valdator: https://stackoverflow.com/questions/39236992/how-to-validate-white-spaces-empty-spaces-angular-2
import {
    Component,
    EventEmitter,
    Input,
    OnChanges,
    OnInit,
    Output,
    SimpleChanges,
    ViewChild,
} from '@angular/core'
import {
    AbstractControl,
    FormControl,
    FormGroup,
    ValidationErrors,
    Validators,
} from '@angular/forms'
import { MatExpansionPanel } from '@angular/material/expansion'
import { FormErrorService } from 'src/app/shared/services/form-error.service'
import { Shipper } from '../models/Shipper'

@Component({
    selector: 'app-shipper-form',
    templateUrl: './shipper-form.component.html',
    styleUrls: ['./shipper-form.component.scss'],
})
export class ShipperFormComponent implements OnInit, OnChanges {
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    @Input() shipperToEdit: Shipper | null = null
    @Input() editing: boolean = false

    @Output() addEvent = new EventEmitter<Shipper>()
    @Output() editEvent = new EventEmitter<Shipper>()

    shipperForm: FormGroup = new FormGroup({
        ShipperID: new FormControl(0),
        CompanyName: new FormControl('', [
            Validators.required,
            Validators.maxLength(40),
            this.noWhitespaceValidator,
        ]),
        Phone: new FormControl('', Validators.maxLength(24)),
    })

    constructor(private formError: FormErrorService) {}

    ngOnInit(): void {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.shipperToEdit) {
            this.ShipperID.setValue(this.shipperToEdit.ShipperID)
            this.CompanyName.setValue(this.shipperToEdit.CompanyName)
            this.Phone.setValue(this.shipperToEdit.Phone)
        }
    }

    // custom validator
    private noWhitespaceValidator(
        control: AbstractControl
    ): ValidationErrors | null {
        const isWhitespace = (control.value || '').trim().length === 0
        return isWhitespace ? { whitespace: true } : null
    }

    togglePanel() {
        this.panel.toggle()
    }

    openPanel() {
        this.panel.open()
    }

    /** Método para enviar el formulario. Diferencia si está editando o creando un nuevo objeto.
     * 
     * Si está editando emite el valor del objeto editado y asigna 'null'
     * a shipperToEdit, para que se deje de mostrar el formulario de edición
     */
    onSubmit() {
        if (this.shipperForm.valid) {
            if (this.editing) {
                this.editEvent.emit(this.shipperForm.value)
                this.shipperToEdit = null
            } else {
                this.addEvent.emit(this.shipperForm.value)
                this.resetFormAndValidation(this.shipperForm)
            }
            this.togglePanel()
        }
    }

    /** Limpia el formulario y reinica los Validators de cada uno de sus controles
     * una vez enviado el formulario
     * @param form formulario a limpiar
     */
    resetFormAndValidation(form: FormGroup) {
        for (let control of Object.values(form.controls)) {
            control.clearValidators()
            control.updateValueAndValidity()
        }
        form.reset()
    }

    // Getters para los controles del formulario
    get ShipperID() {
        return this.shipperForm.get('ShipperID') as FormControl
    }
    get CompanyName() {
        return this.shipperForm.get('CompanyName') as FormControl
    }
    get Phone() {
        return this.shipperForm.get('Phone') as FormControl
    }

    // Métodos para mostrar los posibles errores que pueda tener cada control de acuerdo
    // a sus validadores. Como cada 'mat-error' solo puede mostrar un error a la vez voy
    // checkeando cada error individualmente
    get CompanyNameErrors() {
        if (this.CompanyName.errors?.['required']) {
            return this.formError.RequiredMsg()
        } else if (this.CompanyName.errors?.['maxlength']) {
            return this.formError.MaxLengthMsg(40)
        } else if (this.CompanyName.errors?.['whitespace']) {
            return this.formError.WhitespaceMsg()
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
