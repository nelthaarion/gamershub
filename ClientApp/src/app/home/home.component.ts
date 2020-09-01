import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }
  counter: string = "" ;
  getData(event) {
    console.log("Event")
    this.counter = event
  }
  ngOnInit() {
  }

}
