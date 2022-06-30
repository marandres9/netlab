import { Injectable } from '@angular/core'

@Injectable({
    providedIn: 'root',
})
export class FormErrorService {
    constructor() {}

    RequiredMsg() {
      return 'Field is required'
    }

    MaxLengthMsg(max: number) {
      return `Field must be less than ${max} characters`
    }

    MinMsg(min: number) {
      return `Fiel value must be greater than ${min}`
    }
    
    WhitespaceMsg() {
      return 'Field contains only whitespaces'
    }

    RepeatedID() {
      return 'ID already exists'
    }
}

