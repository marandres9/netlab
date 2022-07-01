// whitespace valdator: https://stackoverflow.com/questions/39236992/how-to-validate-white-spaces-empty-spaces-angular-2
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
import {
    AbstractControl,
    FormControl,
    FormGroup,
    ValidationErrors,
    Validators,
} from '@angular/forms'
import { MatExpansionPanel } from '@angular/material/expansion'
import { FormHelperService } from 'src/app/core/services/form-helper.service'
import { Shipper } from '../models/Shipper'

@Component({
    selector: 'app-shipper-form',
    templateUrl: './shipper-form.component.html',
    styleUrls: ['./shipper-form.component.scss'],
})
export class ShipperFormComponent implements OnChanges, AfterViewInit {
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    @Input() shipperToEdit: Shipper | null = null
    @Input() editing: boolean = false

    @Output() addEvent = new EventEmitter<Shipper>()
    @Output() editEvent = new EventEmitter<Shipper>()

    isExpanded: boolean = false

    form: FormGroup = new FormGroup({
        ShipperID: new FormControl(0),
        CompanyName: new FormControl('', [
            Validators.required,
            Validators.maxLength(40),
            this.formHelper.noWhitespaceValidator,
        ]),
        Phone: new FormControl('', Validators.maxLength(24)),
    })

    constructor(private formHelper: FormHelperService) {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.shipperToEdit && this.editing) {
            this.ShipperID.setValue(this.shipperToEdit.ShipperID)
            this.CompanyName.setValue(this.shipperToEdit.CompanyName)
            this.Phone.setValue(this.shipperToEdit.Phone)
            
            this.openPanel()
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

    openPanel() {
        this.panel.open()
    }

    /** Método para enviar el formulario. Diferencia si está editando o creando un nuevo objeto.
     *
     * Si está editando emite el valor del objeto editado y asigna 'null'
     * a shipperToEdit, para que se deje de mostrar el formulario de edición
     */
    onSubmit() {
        if (this.form.valid) {
            if (this.editing) {
                this.editEvent.emit(this.form.value)
                this.shipperToEdit = null
            } else {
                this.addEvent.emit(this.form.value)
                this.formHelper.resetFormAndValidation(this.form)
            }
            this.togglePanel()
        }
    }

    // Getters para los controles del formulario
    get ShipperID() {
        return this.form.get('ShipperID') as FormControl
    }
    get CompanyName() {
        return this.form.get('CompanyName') as FormControl
    }
    get Phone() {
        return this.form.get('Phone') as FormControl
    }

    // Métodos para mostrar los posibles errores que pueda tener cada control de acuerdo
    // a sus validadores. Como cada 'mat-error' solo puede mostrar un error a la vez voy
    // checkeando cada error individualmente
    get CompanyNameErrors() {
        return this.formHelper.getErrorMsg(this.CompanyName.errors, {maxlength: 40})
    }
    get PhoneErrors() {
        return this.formHelper.getErrorMsg(this.Phone.errors, {maxlength: 24})
    }

    get Title() {
        return this.editing ? 'Edit Shipper' : 'Add Shipper'
    }

    get Description() {
        return this.editing
            ? "Edit an existing Shipper's details"
            : 'Create a new Shipper'
    }
}
