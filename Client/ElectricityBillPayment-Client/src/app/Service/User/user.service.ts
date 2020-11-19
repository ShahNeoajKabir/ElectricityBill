import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  url="https://localhost:44368/api/User/";
  constructor(
    private httpclient: HttpClient
  ) { }

 public AddUser(User:any){
    return this.httpclient.post(this.url+"AddUser" , User);
  }
}
