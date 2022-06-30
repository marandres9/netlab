import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ReactiveFormsModule } from '@angular/forms'
import { RouterModule } from '@angular/router'

import { ToolbarComponent } from './components/toolbar/toolbar.component'
import { StopClickPropagationDirective } from './directives/stop-click-propagation.directive'

import { MatToolbarModule } from '@angular/material/toolbar'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatTableModule } from '@angular/material/table'
import { MatExpansionModule } from '@angular/material/expansion'
import { MatListModule } from '@angular/material/list'
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'
import { MatTreeModule } from '@angular/material/tree'

@NgModule({
    declarations: [ToolbarComponent, StopClickPropagationDirective],
    imports: [CommonModule, MatToolbarModule, MatButtonModule, RouterModule],
    exports: [
        ToolbarComponent,
        StopClickPropagationDirective,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        MatExpansionModule,
        MatListModule,
        MatButtonModule,
        MatIconModule,
        RouterModule,
        MatTreeModule
    ],
})
export class SharedModule {}
