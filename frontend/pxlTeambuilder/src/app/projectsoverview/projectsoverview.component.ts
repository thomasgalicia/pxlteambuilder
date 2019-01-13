import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../services/project/project.service';
import { Project } from '../models/project';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-projectsoverview',
  templateUrl: './projectsoverview.component.html',
  styleUrls: ['./projectsoverview.component.scss']
})
export class ProjectsoverviewComponent implements OnInit {

  private projects : Project[];
  private teacher : boolean;

  constructor(private router : Router, private project : ProjectService, private auth : AuthService) {
    this.teacher = this.auth.User.Role == "teacher";
   }

  ngOnInit() {
    this.project.getAllProjectOfUser().subscribe(data => this.projects = data); 
  }
}
