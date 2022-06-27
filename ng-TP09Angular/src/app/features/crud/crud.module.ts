import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CrudComponent } from './crud.component'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { SharedModule } from 'src/app/shared/shared.module'
import { RouterModule } from '@angular/router'
import { ShipperListComponent } from './shipper/shipper-list/shipper-list.component'
import { ShipperModule } from './shipper/shipper.module'

@NgModule({
    declarations: [CrudComponent],
    imports: [
        CommonModule,
        MatFormFieldModule,
        MatInputModule,
        SharedModule,
        RouterModule,
        ShipperModule
    ],
})
export class CrudModule {}
