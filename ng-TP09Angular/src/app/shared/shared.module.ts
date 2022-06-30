import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ToolbarComponent } from './components/toolbar/toolbar.component'
import { MatToolbarModule } from '@angular/material/toolbar';
import { StopClickPropagationDirective } from './directives/stop-click-propagation.directive'

@NgModule({
    declarations: [ToolbarComponent, StopClickPropagationDirective],
    imports: [CommonModule, MatToolbarModule],
    exports: [ToolbarComponent, StopClickPropagationDirective],
})
export class SharedModule {}
