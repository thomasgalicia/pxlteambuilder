import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Project } from 'src/app/models/project';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {

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

}
