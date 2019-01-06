import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CreateprojectComponent } from './createproject/createproject.component';
import { ProjectsoverviewComponent } from './projectsoverview/projectsoverview.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    CreateprojectComponent,
    ProjectsoverviewComponent,
    ProjectdetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
