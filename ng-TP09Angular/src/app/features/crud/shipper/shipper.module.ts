import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ShipperListComponent } from './shipper-list/shipper-list.component'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'
import { ReactiveFormsModule } from '@angular/forms'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { RouterModule } from '@angular/router'

@NgModule({
    declarations: [ShipperListComponent, ShipperFormComponent],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
    ],
})
export class ShipperModule {}
