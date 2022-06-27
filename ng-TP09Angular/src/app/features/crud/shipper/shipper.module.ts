import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ShipperListComponent } from './shipper-list/shipper-list.component'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'
import { ReactiveFormsModule } from '@angular/forms'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { RouterModule } from '@angular/router';
import { ShipperDetailsComponent } from './shipper-details/shipper-details.component'
import {MatTableModule} from '@angular/material/table';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatListModule} from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button'

@NgModule({
    declarations: [ShipperListComponent, ShipperFormComponent, ShipperDetailsComponent],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        MatExpansionModule,
        MatListModule,
        MatButtonModule,
    ],
})
export class ShipperModule {}
