import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  url="http://localhost:55109/api/User/";
  constructor(
    private httpclient: HttpClient
  ) { }

 public AddUser(User:any){
    return this.httpclient.post(this.url+"AddUser" , User);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public GetById(User:any){
    return this.httpclient.post(this.url+"GetByID",User);
  }
  public UpdateUser(User:any){
    return this.httpclient.post(this.url+"UpdateUser",User);
  }
}
