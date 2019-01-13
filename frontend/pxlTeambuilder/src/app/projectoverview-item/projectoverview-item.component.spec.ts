import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectoverviewItemComponent } from './projectoverview-item.component';

describe('ProjectoverviewItemComponent', () => {
  let component: ProjectoverviewItemComponent;
  let fixture: ComponentFixture<ProjectoverviewItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectoverviewItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectoverviewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
