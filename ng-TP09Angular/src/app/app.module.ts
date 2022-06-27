import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HomeModule } from './features/home/home.module'
import { SharedModule } from './shared/shared.module'
import { NotFoundModule } from './features/not-found/not-found.module'
import { CrudModule } from './features/crud/crud.module';
import { CoreModule } from './core/core.module'

@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HomeModule,
        NotFoundModule,
        CoreModule,
        SharedModule,
        CrudModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
