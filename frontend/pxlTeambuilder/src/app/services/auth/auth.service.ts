import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  private user : User;
  private token : string = "";

  constructor(private http : HttpClient) {
    super();
   }

  public login(email : string, password : string) : Observable<Object>{
    let data = {email : email, password : password };
    return this.http.post<Object>(`${this.baseApiUrl}/users/login`,data);
  }

  public logout(){
    this.token = "";
  }

  public isLoggedIn(){
    return this.token !== "";
  }

  get User(){
    return this.user;
  }

  get Token(){
    return this.token;
  }

  set User(user : User){
    this.user = user;
  }

  set Token(token : string){
    this.token = token;
  }
}
