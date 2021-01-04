import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  url="https://localhost:44318/api/User/";
  constructor(
    private httpclient: HttpClient
  ) { }

 public AddUser(User:any){
    return this.httpclient.post(this.url+"AddUser" , User);
  }

  public GetAll(){
    return this.httpclient.post(this.url+"GetAll","");
  }
  public GetAllMeterReader(){
    return this.httpclient.get(this.url+"GetAllMeterReader");

  }
  public GetAllUnAssinUser(){
    return this.httpclient.get(this.url+"GetAllUnAssinUser");

  }
  

  public SearchUser(search:any){
    return this.httpclient.post(this.url+"SearchUser",search);
  }

  public GetById(User:any){
    return this.httpclient.post(this.url+"GetByID",User);
  }
  public UpdateUser(User:any){
    return this.httpclient.post(this.url+"UpdateUser",User);
  }
}
