import { Component } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { Router } from '@angular/router';
import { SharedService } from './services/shared/sharedservice.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'pxlTeambuilder';

  constructor(private router : Router,private auth : AuthService){
   this.showNavBar();
  }

  logout(event : Event){
    event.preventDefault();
    this.auth.logout();
    this.router.navigate(['/login']);
  }

  showNavBar(){
    return this.auth.isLoggedIn() && this.router.url !== '/login' && this.router.url !== '/';
  }
}
