import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { NotFoundComponent } from './modules/not-found/not-found.component'
import { HomeComponent } from './modules/home/home.component'
import { ShipperListComponent } from './modules/shipper/shipper-list/shipper-list.component'
import { ShipperFormComponent } from './modules/shipper/shipper-form/shipper-form.component'

const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: '/home' },
    { path: 'home', component: HomeComponent },
    { path: 'shippers', component: ShipperListComponent },
    { path: 'shippers/add', component: ShipperFormComponent },
    { path: '**', component: NotFoundComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
