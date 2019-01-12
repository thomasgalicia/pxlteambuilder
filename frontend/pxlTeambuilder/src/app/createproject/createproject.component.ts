import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from '../services/project/project.service';
import { projection } from '@angular/core/src/render3';
import { Project } from '../models/project';
import { AuthService } from '../services/auth/auth.service';
import { HttpResponse } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-createproject',
  templateUrl: './createproject.component.html',
  styleUrls: ['./createproject.component.scss']
})
export class CreateprojectComponent implements OnInit {

  private form : FormGroup
  private loading : boolean = false;

  constructor(private formbuilder: FormBuilder, private project : ProjectService, private auth : AuthService, private toast : ToastrService) {
    
  }

  ngOnInit() {
    this.form = this.formbuilder.group({
      "title" : ['',Validators.required],
      "description": [''],
      'maxstudentspergroup' : [4,Validators.min(1)]
    });
    
  }

  public createProject(){
    this.loading = true;
    let project = new Project();
    let {title, description, maxstudentspergroup} = this.form.controls;
    project.Title = title.value;
    project.Description = description.value;
    project.MaxStudentsPerGroup = maxstudentspergroup.value;
    project.UserId = this.auth.User.Id;
    
    this.project.addProject(project).subscribe(data => this.handleSuccess(), error => this.handleError() );
  }

  private handleSuccess(){
    this.loading = false;
    this.toast.success("Project was succesfully saved","Success")
    this.resetForm()
  }

  private handleError(){
    this.loading = false;
    this.toast.error("Something went wrong when adding project","Oops")
  }

  private resetForm(){
    let {title, description, maxstudentspergroup} = this.form.controls;
    title.setValue('');
    description.setValue("");
    maxstudentspergroup.setValue(4);
  }
}
