import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CreateprojectComponent } from './createproject/createproject.component';
import { ProjectsoverviewComponent } from './projectsoverview/projectsoverview.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';
import { GeneralguardService } from './services/auth/guards/generalguard.service';
import { ParticipateComponent } from './participate/participate.component';
import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  {path: '', redirectTo:'/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent, /*canActivate: [GeneralguardService]*/},
  {path: 'create', component: CreateprojectComponent},
  {path: 'overview', component: ProjectsoverviewComponent},
  {path: 'details', component: ProjectdetailComponent},
  {path: 'participate', component: ParticipateComponent},
  {path: 'edit', component: EditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
