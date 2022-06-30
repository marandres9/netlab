import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ShipperListComponent } from './shipper-list/shipper-list.component'
import { ShipperFormComponent } from './shipper-form/shipper-form.component'
import { ShipperDetailsComponent } from './shipper-details/shipper-details.component'
import { ShipperComponent } from './shipper.component'
import { SharedModule } from 'src/app/shared/shared.module'

@NgModule({
    declarations: [
        ShipperListComponent,
        ShipperFormComponent,
        ShipperDetailsComponent,
        ShipperComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
    ],
})
export class ShipperModule {}
