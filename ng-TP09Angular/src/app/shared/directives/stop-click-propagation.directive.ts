// https://stackoverflow.com/questions/35274028/stop-mouse-event-propagation
import { Directive, HostListener } from '@angular/core'

@Directive({
    selector: '[appStopClickPropagation]',
})
export class StopClickPropagationDirective {
    @HostListener('click', ['$event'])
    public onClick(event: any): void {
        event.stopPropagation()
    }
}

/** Directiva para evitar que un click en un componente padre se siga propagando a los 
 * hijos.
 * 
 * Utilizado en las tablas de los componentes que muestran listas de objetos,
 * ya que deben poder diferenciar un click sobre una fila, y un 
 * click sobre un botón que se encuentra dentro de dicha fila.
 */
