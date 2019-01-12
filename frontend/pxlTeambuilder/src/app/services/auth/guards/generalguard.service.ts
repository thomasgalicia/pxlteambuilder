import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class GeneralguardService implements CanActivate {

  constructor(private auth : AuthService, private router : Router) { }

  canActivate(){
    let loggedIn : boolean = this.auth.isLoggedIn();
    if(!loggedIn){
      this.router.navigate(['/login']);
    }

    return loggedIn;
  }
}
