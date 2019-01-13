import { Component, OnInit } from '@angular/core';
import { delay } from 'q';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Project } from '../models/project';
import { ProjectService } from '../services/project/project.service';
import { Group } from '../models/group';
import { AuthService } from '../services/auth/auth.service';
import { ToastrService, Toast } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-participate',
  templateUrl: './participate.component.html',
  styleUrls: ['./participate.component.scss']
})
export class ParticipateComponent implements OnInit {

  private showSelect : boolean = false;
  private loading : boolean = false;
  private projectId : string;
  private selectedOption;
  private searchForm : FormGroup;
  private groups : Group[];
 

  constructor(private formbuilder : FormBuilder, private projectService : ProjectService,private auth : AuthService, private toast : ToastrService) {
    this.searchForm = this.formbuilder.group({
      'projectId' : ['',Validators.required]
    });
   }

  ngOnInit() {
  }

  async search(){
    this.projectId = this.searchForm.controls.projectId.value;
    this.loading = true;
    await this.projectService.getAllGroupsOfProject(this.projectId).subscribe(data =>  this.handleSearchSuccess(data), (error : HttpErrorResponse) =>  this.toast.error(error.error))
    this.loading = false;
  }

  public participate(){
    let selectedGroup : Group = this.groups.filter(group => {
      return group.Name === this.selectedOption;
    })[0];

    this.projectService.participateToProject(this.auth.User.Id,this.projectId,selectedGroup.Id)
                       .subscribe(success =>this.handleParticipateSuccess(), (error : HttpErrorResponse) => this.toast.error(error.error,"Error"))
  }

  private handleSearchSuccess(data){
    this.groups = data;
    this.showSelect = true;
  }

  private handleParticipateSuccess(){
    this.toast.success("U are now participating","Success");
    this.resetForm();
  }

  private resetForm(){
    this.showSelect = false;
    this.searchForm.controls.projectId.setValue('');
  }
}
