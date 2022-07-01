import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ShipperModule } from './shipper/shipper.module'
import { HomeModule } from './home/home.module'
import { RegionModule } from './region/region.module'
import { NotFoundModule } from './not-found/not-found.module'

@NgModule({
    declarations: [],
    imports: [CommonModule, HomeModule, ShipperModule, RegionModule, NotFoundModule],
    exports: [HomeModule, ShipperModule, RegionModule, NotFoundModule],
})
export class ModulesModule {}
