import { Injectable } from '@angular/core'
import {
    BehaviorSubject,
    from,
    observable,
    Observable,
    of,
    Subject,
} from 'rxjs'

@Injectable({
    providedIn: 'root',
})
export class FormListenerService<T> {
    private formValueSubject: Subject<T> = new Subject<T>()
    formValue$: Observable<T> = this.formValueSubject

    constructor() {}

    setFormValue(value: T) {
        this.formValueSubject.next(value)
    }

    get FormValue$() {
        return this.formValue$
    }
}
