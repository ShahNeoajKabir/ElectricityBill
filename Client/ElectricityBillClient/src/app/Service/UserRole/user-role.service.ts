import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService {
  url="https://localhost:44318/api/UserRole/";

  constructor(private httpclient:HttpClient) { }

  public AddUserRole(UserRole:any){
    return this.httpclient.post(this.url+"AddUserRole",UserRole);

  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public Search(search:any){
    return this.httpclient.post(this.url+"SearchUserRole",search);
  }

  public UpdateUserRole(UserRole:any){
    return this.httpclient.post(this.url+"UpdateUserRole",UserRole);
  }
  public GetById(UserRole:any){
    return this.httpclient.post(this.url+"GetById",UserRole);
  }


}
