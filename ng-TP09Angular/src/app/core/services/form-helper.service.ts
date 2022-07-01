import { Injectable } from '@angular/core'
import { AbstractControl, FormGroup, ValidationErrors } from '@angular/forms'

@Injectable({
    providedIn: 'root',
})
export class FormHelperService {
    constructor() {}

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

    /** Verifica que el campo no contenga solo espacios en blano */
    noWhitespaceValidator(control: AbstractControl): ValidationErrors | null {
        const isWhitespace = (control.value || '').trim().length === 0
        return isWhitespace ? { whitespace: true } : null
    }

    /** Devuelve mensajes de errores.
     *
     * @param errors Los errores de validación del formControl
     * @param validatorParams Objeto con los parámetros de validación del formControl. 
     * Por ej: {min: 0, maxlength: 24}
     */
    getErrorMsg(errors: ValidationErrors | null, validatorParams?: ValidatorParams) {
        if (errors?.['required']) {
            return this.RequiredMsg()
        } else if (errors?.['whitespace']) {
            return this.WhitespaceMsg()
        } else if (errors?.['repeatedID']) {
            return this.RepeatedID()
        } else if (errors?.['maxlength'] && validatorParams?.maxlength !== undefined) {
            return this.MaxLengthMsg(validatorParams.maxlength)
        } else if (errors?.['minlength'] && validatorParams?.minlength !== undefined) {
            return this.MinLengthMsg(validatorParams.minlength)
        } else if (errors?.['max'] && validatorParams?.max !== undefined) {
            return this.MaxMsg(validatorParams.max)
        } else if (errors?.['min'] && validatorParams?.min !== undefined) {
            return this.MinMsg(validatorParams.min)
        } else {
            return ''
        }
    }

    RequiredMsg() {
        return 'Field is required'
    }
    MaxLengthMsg(max: number) {
        return `Field length must be shorter than ${max} characters`
    }
    MinLengthMsg(min: number) {
        return `Field length must be longer than ${min} characters`
    }
    MaxMsg(max: number) {
        return `Field value must be less than ${max}`
    }
    MinMsg(min: number) {
        return `Field value must be greater than ${min}`
    }
    WhitespaceMsg() {
        return 'Field contains only whitespaces'
    }
    RepeatedID() {
        return 'ID already exists'
    }
}

interface ValidatorParams {
    min?: number
    max?: number
    minlength?: number
    maxlength?: number
}
