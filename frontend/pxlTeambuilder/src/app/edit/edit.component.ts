import { Component, OnInit, OnDestroy } from '@angular/core';
import { Project } from '../models/project';
import { Group } from '../models/group';
import { ProjectService } from '../services/project/project.service';
import { group } from '@angular/animations';
import { CdkDropList } from '@angular/cdk/drag-drop';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth/auth.service';
import { User } from '../models/user';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit,OnDestroy {
 

  
  private project : Project;
  private groups : Group[]
  private updates = [];
  private changesMade = false;

  
  constructor(private projectService : ProjectService, private toast : ToastrService, private auth : AuthService) {
  }

  
  ngOnInit() {
    this.project = this.projectService.SelectedProject;
    this.projectService.getAllGroupsOfProject(this.project.Id).subscribe(data => {
      this.groups = this.setUnassignedAsLast(data);
    });
  }

  
  ngOnDestroy(){
    this.projectService.clearSelectedProject();
  }

  
  drop(event : Event){
   
   if(!this.isSameDropList(event)){
    let sourceGroupIndex : number = this.getContainerIndex(event['previousContainer']);
    let destinationGroupIndex : number = this.getContainerIndex(event['container']);

    let sourceGroup : Group = this.groups[sourceGroupIndex];
    let destinationGroup : Group = this.groups[destinationGroupIndex];
   
    if(this.groupIsFull(destinationGroup)){
      this.toast.error("the group is full", "Error");
    }

    else{
      let newIndex = parseInt(event['currentIndex']);
      let oldIndex = parseInt(event['previousIndex']);
  
      let selectedStudent : User = sourceGroup.TeamMembers[oldIndex];
      sourceGroup.TeamMembers.splice(oldIndex,1);
      destinationGroup.TeamMembers.splice(newIndex,0,selectedStudent);

      const updateObject = {
        userId : selectedStudent.Id,
        oldGroupId : sourceGroup.Id,
        newGroupId : destinationGroup.Id
      }

      this.updates.push(updateObject);
      this.changesMade = true;
    }
   }
  }

  
  saveUpdates(){
    this.projectService.updateProject(this.project.Id,this.updates).subscribe(data => {
      this.toast.success('The groups have been successfully updated','Success')
      this.changesMade = false;
      this.updates = [];
  }
   ,(error :HttpErrorResponse)=> this.toast.error(error.error,'Error'));
  }

  generateDropListId(index : number){
   return index;
  }

  private isSameDropList(event : Event) : boolean{
    return event['previousContainer'] === event['container'];
  }

  private setUnassignedAsLast(data : Group[]){
    let unassignedGroup =  data.filter((group : Group) => group.Name.toLowerCase() === "unassigned")[0];
    let indexUnassigned = data.indexOf(unassignedGroup);
    let lastItem = data[data.length-1];
    data[indexUnassigned] = lastItem;
    data[data.length-1] = unassignedGroup;
    return data;
  }

  private getContainerIndex(container : CdkDropList) : number{
   return parseInt(container['id'])
  }

  private groupIsFull(group : Group){
    return group.TeamMembers.length == this.project.MaxStudentsPerGroup;
  }
}
