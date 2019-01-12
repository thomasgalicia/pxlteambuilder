import { Component, OnInit } from '@angular/core';
import { delay } from 'q';

@Component({
  selector: 'app-participate',
  templateUrl: './participate.component.html',
  styleUrls: ['./participate.component.scss']
})
export class ParticipateComponent implements OnInit {

  private showSelect : boolean = false;
  private loading : boolean = false;

  constructor() { }

  ngOnInit() {
  }

  async search(){
    this.loading = true;
    await delay(3000);
    this.loading = false;
    this.showSelect = true;
  }
}
