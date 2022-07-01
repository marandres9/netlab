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
import { ItemActionButtonsComponent } from './components/item-action-buttons/item-action-buttons.component'
import { TableActionButtonsComponent } from './components/table-action-buttons/table-action-buttons.component'
import { MatTooltipModule } from '@angular/material/tooltip'

@NgModule({
    declarations: [
        ToolbarComponent,
        StopClickPropagationDirective,
        ItemActionButtonsComponent,
        TableActionButtonsComponent,
    ],
    imports: [
        CommonModule,
        MatToolbarModule,
        MatButtonModule,
        MatIconModule,
        RouterModule,
        MatTooltipModule,
    ],
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
        MatTreeModule,
        ItemActionButtonsComponent,
        TableActionButtonsComponent,
    ],
})
export class SharedModule {}
