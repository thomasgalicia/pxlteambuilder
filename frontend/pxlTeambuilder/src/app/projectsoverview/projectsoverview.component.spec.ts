import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectsoverviewComponent } from './projectsoverview.component';

describe('ProjectsoverviewComponent', () => {
  let component: ProjectsoverviewComponent;
  let fixture: ComponentFixture<ProjectsoverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectsoverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectsoverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
