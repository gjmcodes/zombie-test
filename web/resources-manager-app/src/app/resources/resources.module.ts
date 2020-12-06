import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResourcesIndexComponent } from './resources-index/resources-index.component';
import { ResourcesCreateComponent } from './resources-create/resources-create.component';
import { ResourcesEditComponent } from './resources-edit/resources-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ResourcesIndexComponent,
    ResourcesCreateComponent,
    ResourcesEditComponent,
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule
  ],
  exports: [
    ResourcesIndexComponent,
    ResourcesCreateComponent,
    ResourcesEditComponent,
  ]
})
export class ResourcesModule { }
