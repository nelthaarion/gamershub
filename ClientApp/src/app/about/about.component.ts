import { Component, OnInit, Output  , EventEmitter} from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  constructor() { }
  @Output() setName = new EventEmitter<string>();
  counter = 0 ;
  AddOneMore(){
    console.log("CLICKED")
    this.counter++;
    this.setName.emit(this.counter.toString())
  }
  ngOnInit() {
  }

}
