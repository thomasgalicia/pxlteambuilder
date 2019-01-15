import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from '../base.service';
import { SharedService } from '../shared/sharedservice.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

 

  constructor(private http : HttpClient, private shared : SharedService) {
    super();
   }

  public login(email : string, password : string) : Observable<Object>{
    let data = {email : email, password : password };
    return this.http.post<Object>(`${this.baseApiUrl}/users/login`,data);
  }

  public logout(){
    this.Token = "";
  }

  public isLoggedIn(){
    return this.Token !== "";
  }

  get User(){
    return this.shared.User;
  }

  get Token(){
    return this.shared.AuthToken;
  }

  set User(user : User){
    this.shared.User = user;
  }

  set Token(token : string){
    this.shared.AuthToken = token;
  }
}
