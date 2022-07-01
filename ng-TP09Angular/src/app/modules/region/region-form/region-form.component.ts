import {
    AfterViewInit,
    Component,
    EventEmitter,
    Input,
    OnChanges,
    Output,
    SimpleChanges,
    ViewChild,
} from '@angular/core'

import { FormBuilder, FormControl, Validators } from '@angular/forms'
import { MatExpansionPanel } from '@angular/material/expansion'
import { Region } from '../model/Region'
import { FormHelperService } from 'src/app/core/services/form-helper.service'

@Component({
    selector: 'app-region-form',
    templateUrl: './region-form.component.html',
    styleUrls: ['./region-form.component.scss'],
})
export class RegionFormComponent implements OnChanges, AfterViewInit {
    @ViewChild(MatExpansionPanel) panel!: MatExpansionPanel

    /** Se recibe si se intento crear un objeto invalido */
    @Input() invalidObject: Region | null = null

    @Input() objectToEdit: Region | null = null
    /** Indica para que se usa el componente */
    @Input() editing: boolean = false

    @Output() addEvent = new EventEmitter<Region>()
    @Output() editEvent = new EventEmitter<Region>()

    isExpanded: boolean = false

    form = this.fb.group({
        RegionID: ['', [Validators.required, Validators.min(0)]],
        RegionDescription: [
            '',
            [
                Validators.required,
                Validators.maxLength(50),
                this.formHelper.noWhitespaceValidator,
            ],
        ],
    })

    constructor(
        private fb: FormBuilder,
        /** El servicio FormHelper provee Validators personalizados, un método para
         * resetear los campos y Validators del formulario y métodos para obtener
         * los mensajes de error que puede tener cada campo
         */
        private formHelper: FormHelperService
    ) {}

    ngOnChanges(changes: SimpleChanges): void {
        // Si recibe un objeto para editar prepara el formulario de edición
        if (this.objectToEdit && this.editing) {
            this.form.setValue({
                RegionID: this.objectToEdit.RegionID,
                RegionDescription: this.objectToEdit.RegionDescription.trim(),
            })
            this.RegionID.disable()
            this.openPanel()
        }
        /**
         * Si se intentó enviar un objeto invalido, se reibe un invalidObject y se cargan
         * los datos en el formulario y se da aviso del error. Solo es necesario para
         * la tabla Region porque no tiene ID autoincremental y es posible que el usuario
         * ingrese un ID repetido.
         *
         * Para cualquier otra entidad con ID autoincremental, los validadores del
         * formulario deberian asegurar que el objeto a crear sea válido.
         *
         * El error de ID repetido se settea manualmente ya que este componente no tiene
         * acceso a la lista de entidades, por lo que no puedo crear un validador que
         * verifique que el ID no sea repetido
         */
        if (this.invalidObject && !this.editing) {
            this.form.setValue({
                RegionID: this.invalidObject.RegionID,
                RegionDescription: this.invalidObject.RegionDescription,
            })
            this.RegionID.setErrors({ repeatedID: true })
            this.openPanel()
        }
    }

    /** Mediante la prop. 'isExpanded' se notifica a la vista para mostrar (o no)
     * la descripción del panel. */
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
     * a shipperToEdit, para que se deje de mostrar el contenido del formulario de edición
     */
    onSubmit() {
        if (this.form.valid) {
            if (this.objectToEdit) {
                this.editEvent.emit(this.form.getRawValue())
                this.objectToEdit = null
            } else {
                this.addEvent.emit(this.form.value)
                this.formHelper.resetFormAndValidation(this.form)
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

    // Getters para los errores de cada formControl
    get RegionIDErrors() {
        return this.formHelper.getErrorMsg(this.RegionID.errors, { min: 0 })
    }

    get RegionDescriptionErrors() {
        return this.formHelper.getErrorMsg(this.RegionDescription.errors, {
            maxlength: 50,
        })
    }

    // Getters para mostrar texto en la vista
    get Title() {
        return this.editing ? 'Edit Region' : 'Add Region'
    }

    get Description() {
        return this.editing ? "Edit an existing Region's details" : 'Create a new Region'
    }
}
