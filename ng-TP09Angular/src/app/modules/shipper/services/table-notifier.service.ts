import { Injectable } from '@angular/core'
import {
    Observable,
    Subject,
} from 'rxjs'

@Injectable({
    providedIn: 'root',
})
export class TableNotifierService {
    private tableNotifierSubject = new Subject<boolean>()

    /** Observable del suejeto notificador. Los componentes que quieran ser notificados
     * se pueden suscribir en OnInit().
     */
    public tableNotifier$: Observable<boolean> = this.tableNotifierSubject

    constructor() {}

    /** Utilizado para actualizar el componente 'table' ante una edición o eliminiación 
     * de un objeto.
     * 
     * Para actualizar una tabla, el sujeto debe emitir 'true'. El componente 'table' será
     * notificado y actualizara los datos mostrados.
     */
    notifyTable(value: boolean) {
        this.tableNotifierSubject.next(value)
    }
}
