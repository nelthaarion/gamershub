import { Component, OnInit, ChangeDetectionStrategy, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'Navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class NavbarComponent implements OnInit , OnDestroy {

  constructor(private authService : AuthService) { }
  ngOnDestroy(): void {

  }

  ngOnInit() {
      console.log(this.loggedIn())
  }


  isLoggedIn: boolean = false;

  login(form: NgForm){
    const data = {username: form.value.username , password: form.value.password}
    if(form.valid)
    {
        this.authService.login(data).subscribe(next => this.loggedIn()) ;
    }

  }

  loggedIn(){
      const token = localStorage.getItem("token");
      return !!token;
  }
  logout(){
    localStorage.removeItem("token")
  }
}
