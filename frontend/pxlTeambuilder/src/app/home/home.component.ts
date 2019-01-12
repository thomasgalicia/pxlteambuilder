import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private role : string

  constructor(private router : Router, private auth : AuthService) { 
    this.role = this.auth.User.Role
  }

  ngOnInit() {
  }

  newProjectClick(){
    this.router.navigate(['/create']);
  }

  viewProjectsClick(){
    this.router.navigate(['/overview'])
  }

  participateClick(){
    this.router.navigate(['/participate'])
  }

  isTeacher(){
    return this.role === 'teacher'
  }
}
