import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private authService : AuthService , private router : Router) { }
  registerError: boolean = false ;
  ngOnInit() {
  }
  onSubmit(form: NgForm){
      const user = {username: form.value.username , password: form.value.password}
      this.authService.register(user).subscribe(data => {
            this.authService.login(user).subscribe(()=> this.router.navigate(['']))
      } , err=> {
        this.registerError = true
      })
  }
}
