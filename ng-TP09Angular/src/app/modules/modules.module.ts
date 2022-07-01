import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ShipperModule } from './shipper/shipper.module'
import { HomeModule } from './home/home.module'
import { RegionModule } from './region/region.module'

@NgModule({
    declarations: [],
    imports: [CommonModule, HomeModule, ShipperModule, RegionModule],
    exports: [HomeModule, ShipperModule, RegionModule],
})
export class ModulesModule {}
