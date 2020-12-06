import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ResourcesIndexComponent } from './resources/resources-index/resources-index.component';
import { ResourcesCreateComponent } from './resources/resources-create/resources-create.component';
import { ResourcesEditComponent } from './resources/resources-edit/resources-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ResourcesModule } from './resources/resources.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    AppRoutingModule,
    ResourcesModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
