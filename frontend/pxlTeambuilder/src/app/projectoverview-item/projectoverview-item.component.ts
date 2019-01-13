import { Component, OnInit, Input } from '@angular/core';
import { Project } from '../models/project';
import { Router } from '@angular/router';
import { ProjectService } from '../services/project/project.service';

@Component({
  selector: 'app-projectoverview-item',
  templateUrl: './projectoverview-item.component.html',
  styleUrls: ['./projectoverview-item.component.scss']
})
export class ProjectoverviewItemComponent implements OnInit {

  @Input() project : Project

  constructor(private router : Router, private projectService : ProjectService) { }

  ngOnInit() {
  }

  projectViewClick(event : Event){
    event.preventDefault();
    this.projectService.SelectedProject = this.project;
    this.router.navigate(['/details'])
  }


}
