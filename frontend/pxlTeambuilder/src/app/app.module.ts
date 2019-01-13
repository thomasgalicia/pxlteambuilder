import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CreateprojectComponent } from './createproject/createproject.component';
import { ProjectsoverviewComponent } from './projectsoverview/projectsoverview.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';
import { AuthService } from './services/auth/auth.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GeneralguardService } from './services/auth/guards/generalguard.service';
import { ParticipateComponent } from './participate/participate.component';
import { ProjectService } from './services/project/project.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProjectoverviewItemComponent } from './projectoverview-item/projectoverview-item.component';
import { GroupViewItemComponent } from './group-view-item/group-view-item.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    CreateprojectComponent,
    ProjectsoverviewComponent,
    ProjectdetailComponent,
    ParticipateComponent,
    ProjectoverviewItemComponent,
    GroupViewItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [AuthService, GeneralguardService, ProjectService],
  bootstrap: [AppComponent]
})
export class AppModule { }
