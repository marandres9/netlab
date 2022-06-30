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
    FormBuilder,
    FormControl,
    FormGroup,
    ValidationErrors,
    Validators,
} from '@angular/forms'
import { MatExpansionPanel } from '@angular/material/expansion'
import { Region } from '../model/Region'
import { FormErrorService } from 'src/app/shared/services/form-error.service'

@Component({
    selector: 'app-region-form',
    templateUrl: './region-form.component.html',
    styleUrls: ['./region-form.component.scss'],
})
export class RegionFormComponent implements OnInit, OnChanges, AfterViewInit {
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    @Input() objectToEdit: Region | null = null
    @Input() editing: boolean = false

    @Output() addEvent = new EventEmitter<Region>()
    @Output() editEvent = new EventEmitter<Region>()

    isExpanded: boolean = false

    form = this.fb.group({
        RegionID: [, [Validators.required, Validators.min(0)]],
        RegionDescription: [
            '',
            [Validators.required, Validators.maxLength(50), this.noWhitespaceValidator],
        ],
    })

    constructor(private fb: FormBuilder, private formError: FormErrorService) {}

    ngOnInit(): void {}

    ngOnChanges(changes: SimpleChanges): void {
        if (this.objectToEdit) {
            this.RegionID.setValue(this.objectToEdit.RegionID)
            this.RegionDescription.setValue(this.objectToEdit.RegionDescription)
        }
    }

    ngAfterViewInit(): void {
        this.panel.expandedChange.subscribe((expanded) => {
            this.isExpanded = expanded
        })
    }

    // custom validator
    private noWhitespaceValidator(control: AbstractControl): ValidationErrors | null {
        const isWhitespace = (control.value || '').trim().length === 0
        return isWhitespace ? { whitespace: true } : null
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

    togglePanel() {
        this.panel.toggle()
    }

    expandPanel() {
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
                this.objectToEdit = null
            } else {
                this.addEvent.emit(this.form.value)
                this.resetFormAndValidation(this.form)
            }
            this.togglePanel()
        }
    }

    // Getters para los controles del formulario
    get RegionID() {
        return this.form.get('RegionID') as FormControl
    }
    get RegionDescription() {
        return this.form.get('RegionDescription') as FormControl
    }

    get RegionDescriptionErrors() {
        if (this.RegionDescription.errors?.['required']) {
            return this.formError.requiredMsg()
        } else if (this.RegionDescription.errors?.['maxlength']) {
            return this.formError.MaxLengthMsg(50)
        } else if (this.RegionDescription.errors?.['whitespace']) {
            return this.formError.WhitespaceMsg()
        } else {
            return ''
        }
    }
}
