import { Component, OnInit, Input } from '@angular/core';
import { Group } from '../models/group';

@Component({
  selector: 'app-group-view-item',
  templateUrl: './group-view-item.component.html',
  styleUrls: ['./group-view-item.component.scss']
})
export class GroupViewItemComponent implements OnInit {

  @Input() group : Group

  constructor() { }

  ngOnInit() {
  }

}
