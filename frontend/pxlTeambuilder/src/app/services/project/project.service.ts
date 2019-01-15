import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams} from '@angular/common/http';
import { Project } from 'src/app/models/project';
import { AuthService } from '../auth/auth.service';
import { map } from 'rxjs/operators';
import { Group } from 'src/app/models/group';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {

  private selectedProject : Project;

  constructor(private http : HttpClient, private auth : AuthService) {
    super();
  }

  public addProject(project : Project){
    let data = {
      userId : project.UserId,
      title : project.Title,
      description : project.Description,
      maxstudentspergroup : project.MaxStudentsPerGroup
    };

    const options = {
      headers : {
        Authorization : `Bearer ${this.auth.Token}`,
        'Content-Type' : 'application/json'
      }
    }

    return this.http.post(`${this.baseApiUrl}/projects/new`,data,options);
  }

  public addGroupToProject(userId : number, projectId : string, groupName : string){
    const data = {
      userId : userId,
      groupName : groupName
    }
    const options = {
      headers : {
        Authorization : `Bearer ${this.auth.Token}`,
        'Content-Type' : 'application/json'
      }
    }

    return this.http.post(`${this.baseApiUrl}/projects/${projectId}/groups/new`,data,options);
  }

  public getAllProjectOfUser() : Observable<Project[]>{
    let userId = this.auth.User.Id;
    const options = {
      headers : {
        Authorization : `Bearer ${this.auth.Token}`
      }
    }

    return this.http.get<Project[]>(`${this.baseApiUrl}/projects/user/${userId}`,options).pipe(map(this.parsePojoArrayToProjects));
  }

  public getAllGroupsOfProject(projectId : string) : Observable<Group[]>{
    const options = {
      headers : {
        Authorization : `Bearer ${this.auth.Token}`
      }
    }
    return this.http.get<Group[]>(`${this.baseApiUrl}/projects/${projectId}/groups`,options).pipe(map((pojo : Object[]) => this.parsePojoArrayToGroups(pojo)));
  }

  public participateToProject(userId : number, projectId : string, groupId : string){
    const data = {
      userId : userId,
      projectId : projectId,
      groupId : groupId
    }
    const options  = {
      headers : {
        Authorization : `Bearer ${this.auth.Token}`
      },
    }
    console.log(options);
    return this.http.post(`${this.baseApiUrl}/projects/participate`,data,options);
  }

  public get SelectedProject(){
    return this.selectedProject;
  }

  public set SelectedProject(project : Project){
    this.selectedProject = project;
  }

  //parsers
  private parsePojoArrayToProjects(pojoArray : Object[]): Project[]{
    let projects : Project[] = [];
    pojoArray.forEach(pojo => {
      let project : Project = new Project();
      project.Id = pojo['projectId'];
      project.UserId = pojo['userId'];
      project.Title = pojo['title'];
      project.Description = pojo['description'];
      project.MaxStudentsPerGroup = pojo['maxstudentspergroup'];
      projects.push(project);
    })
    return projects;
  }

  private parsePojoArrayToGroups(pojoArray : Object[]) : Group[]{
    let groups = [];
    pojoArray.forEach((pojoObject : Object) => {groups.push(this.parsePojoObjectToGroup(pojoObject))});
    return groups;
    
  }

  private parsePojoObjectToGroup(pojoObject : Object) : Group{
    let group : Group = new Group();
    group.Id = pojoObject['groupId'];
    group.Name = pojoObject['name'];
    group.ProjectId = pojoObject['projectId'];
    let teamMembers = []

    pojoObject['teamMembers'].forEach((teamMember : Object) => teamMembers.push(this.parsePojoObjectToUser(teamMember)));
    group.TeamMembers = teamMembers;
    return group;
  }

  private parsePojoObjectToUser(pojoObject : Object) : User{
    let user : User = new User();
    user.Id = pojoObject['id'];
    user.Email = pojoObject['email']
    user.Name = pojoObject['name'];
    return user;
  }

}
