import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegionDetailsComponent } from './region-details/region-details.component';
import { RegionFormComponent } from './region-form/region-form.component';
import { RegionListComponent } from './region-list/region-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RegionComponent } from './region.component';



@NgModule({
  declarations: [
    RegionDetailsComponent,
    RegionFormComponent,
    RegionListComponent,
    RegionComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class RegionModule { }
