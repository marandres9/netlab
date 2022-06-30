import { Injectable } from '@angular/core'

@Injectable({
    providedIn: 'root',
})
export class FormErrorService {
    constructor() {}

    requiredMsg() {
      return 'Field is required'
    }

    MaxLengthMsg(max: number) {
      return `Field must be less than ${max} characters`
    }

    WhitespaceMsg() {
      return 'Field contains only whitespaces'
    }
}

enum FormErrors {
    REQUIRED,
    MAXLENGTH,
    MAX,
    MIN,
}
