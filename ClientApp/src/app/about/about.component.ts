import { Component, OnInit, Output  , EventEmitter} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  constructor(private http: HttpClient) { }
  @Output() setName = new EventEmitter<string>();
  counter = 0 ;
  token ;
  login(username: string , password: string){
    const data = {username , password}
    console.log(data);

    this.http.post<{token: string}>('http://localhost:5000/api/auth/login' , data)
    .subscribe(token => this.token = token.token , (err)=> console.log(err))
  }
  ngOnInit() {
  }

}
