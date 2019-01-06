import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CreateprojectComponent } from './createproject/createproject.component';
import { ProjectsoverviewComponent } from './projectsoverview/projectsoverview.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';

const routes: Routes = [
  {path: '', redirectTo:'/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent},
  {path: 'create', component: CreateprojectComponent},
  {path: 'overview', component: ProjectsoverviewComponent},
  {path: 'details', component: ProjectdetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
