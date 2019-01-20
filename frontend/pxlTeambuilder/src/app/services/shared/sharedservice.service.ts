import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user';
import { Project } from 'src/app/models/project';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }


  public get AuthToken(){
    return localStorage.getItem('token');
  }

  public set AuthToken(token : string){
    localStorage.setItem('token',token);
  }

  public set User(user : User){
    localStorage.setItem('user', JSON.stringify(user));
  }

  public get User() : User{
    let jsonUser = JSON.parse(localStorage.getItem('user'));
    let user : User = new User();
    user.Id = parseInt(jsonUser['id']);
    user.Email = jsonUser['email'];
    user.Name = jsonUser['name'];
    user.Role = jsonUser['role'];
    return user;
  }

  public set SelectedProject(project : Project){
    localStorage.setItem('selectedProject',JSON.stringify(project));
  }

  public get SelectedProject(){
    let jsonObject = JSON.parse(localStorage.getItem('selectedProject'));
    let project : Project = new Project();
    project.Id = jsonObject['id'];
    project.Title = jsonObject['title'];
    project.Description = jsonObject['decription'];
    project.UserId = parseInt(jsonObject['userId']);
    project.MaxStudentsPerGroup = parseInt(jsonObject['maxStudentsPerGroup']);
    return project;
  }

  public clearSelectedProject(){
    localStorage.removeItem('selectedProject');
  
  }

  public cleanup(){
    localStorage.removeItem('selectedProject');
    localStorage.removeItem('token');
    localStorage.removeItem('user');
  }
}
