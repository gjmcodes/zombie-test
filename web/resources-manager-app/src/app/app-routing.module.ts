import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResourcesCreateComponent } from './resources/resources-create/resources-create.component';
import { ResourcesEditComponent } from './resources/resources-edit/resources-edit.component';
import { ResourcesIndexComponent } from './resources/resources-index/resources-index.component';

const routes: Routes = [
  { path: 'resources', component: ResourcesIndexComponent },
  { path: '', redirectTo: '/resources', pathMatch: 'full' },
  { path: 'resources/create', component: ResourcesCreateComponent },
  { path: 'resources/edit/:id', component: ResourcesEditComponent },




];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    useHash: true
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
