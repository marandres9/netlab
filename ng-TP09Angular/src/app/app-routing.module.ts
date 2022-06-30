import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { NotFoundComponent } from './modules/not-found/not-found.component'
import { HomeComponent } from './modules/home/home.component'
import { ShipperComponent } from './modules/shipper/shipper.component'
import { RegionComponent } from './modules/region/region.component'

const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: '/home' },
    { path: 'home', component: HomeComponent },
    { path: 'shipper', component: ShipperComponent },
    { path: 'region', component: RegionComponent },
    { path: '**', component: NotFoundComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
