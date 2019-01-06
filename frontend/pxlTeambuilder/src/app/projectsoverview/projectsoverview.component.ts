import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-projectsoverview',
  templateUrl: './projectsoverview.component.html',
  styleUrls: ['./projectsoverview.component.scss']
})
export class ProjectsoverviewComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit() {
  }

  navigateToDetail(event : Event){
    event.preventDefault();
    this.router.navigate(['/details']);
  }
}
