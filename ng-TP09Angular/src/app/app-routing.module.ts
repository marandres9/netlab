import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { CrudComponent } from './features/crud/crud.component'
import { ShipperFormComponent } from './features/crud/shipper/shipper-form/shipper-form.component'
import { ShipperListComponent } from './features/crud/shipper/shipper-list/shipper-list.component'
import { HomeComponent } from './features/home/home.component'
import { NotFoundComponent } from './features/not-found/not-found.component'

const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: '/home' },
    { path: 'home', component: HomeComponent },
    {
        path: 'crud',
        component: CrudComponent,
        children: [
            { path: 'shippers', component: ShipperListComponent },
            { path: 'shippers/add', component: ShipperFormComponent },
        ],
    },
    { path: '**', component: NotFoundComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
