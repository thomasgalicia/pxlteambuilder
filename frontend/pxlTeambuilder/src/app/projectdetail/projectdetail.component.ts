import { Component, OnInit, OnDestroy } from '@angular/core';
import { Project } from '../models/project';
import { ProjectService } from '../services/project/project.service';
import { Group } from '../models/group';

@Component({
  selector: 'app-projectdetail',
  templateUrl: './projectdetail.component.html',
  styleUrls: ['./projectdetail.component.scss']
})
export class ProjectdetailComponent implements OnInit,OnDestroy {
  
  private project : Project;
  private groups : Group[];

  constructor(private projectService : ProjectService) { 
    this.project = this.projectService.SelectedProject;
    this.projectService.getAllGroupsOfProject(this.project.Id).subscribe(data => this.groups = data);  
  }

  ngOnInit() {
    
  }

  ngOnDestroy(){    
    this.projectService.SelectedProject = undefined;
  }


}
