import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { User } from '../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private email : string;
  private password : string;

  constructor(private router: Router, private auth : AuthService) { }

  ngOnInit() {
  }

  //TODO: add input check
  //TODO: add error handling
  login(){
    this.auth.login(this.email,this.password).subscribe(data => {
      this.auth.Token = data['token'];
      this.auth.User = this.mapResponse(data);
      this.router.navigate(['/home']);
    })
  }

  mapResponse(pojo : Object){
    let user : User = new User();
    user.Email = pojo['email'];
    user.Id = pojo['id'];
    user.Name = pojo['name'];
    user.Role = pojo['role'];
    return user;
  }
}
