import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CrudComponent } from './crud.component'
import { MatFormFieldModule } from '@angular/material/form-field'
import {MatInputModule} from '@angular/material/input';

@NgModule({
    declarations: [CrudComponent],
    imports: [CommonModule, MatFormFieldModule, MatInputModule],
})
export class CrudModule {}
