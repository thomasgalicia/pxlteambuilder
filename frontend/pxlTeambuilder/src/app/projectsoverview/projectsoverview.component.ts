import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectService } from '../services/project/project.service';
import { Project } from '../models/project';

@Component({
  selector: 'app-projectsoverview',
  templateUrl: './projectsoverview.component.html',
  styleUrls: ['./projectsoverview.component.scss']
})
export class ProjectsoverviewComponent implements OnInit {

  private projects : Project[];

  constructor(private router : Router, private project : ProjectService) { }

  ngOnInit() {
    this.project.getAllProjectOfUser().subscribe(data => this.projects = data); 
  }
}
