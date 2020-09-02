import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from "rxjs/operators"

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseApi = "http://localhost:5000/api/auth"
  constructor(private http: HttpClient) {}

  login(formData) {
    return this.http.post(this.baseApi + "/login", {
      username: formData.username,
      password: formData.password
    }).
    pipe(map((data:any) =>
      {     if (data)
           {localStorage.setItem("token", data.token) ;
            return data}
      }))
  }

  register(data){

   return this.http.post(this.baseApi+"/register", data, {observe: 'response'})
  }

}
