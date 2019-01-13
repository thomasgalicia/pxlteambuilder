import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupViewItemComponent } from './group-view-item.component';

describe('GroupViewItemComponent', () => {
  let component: GroupViewItemComponent;
  let fixture: ComponentFixture<GroupViewItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupViewItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupViewItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
