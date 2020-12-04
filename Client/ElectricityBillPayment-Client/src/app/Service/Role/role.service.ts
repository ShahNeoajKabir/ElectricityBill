import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  url="http://localhost:55109/api/Role/";


  constructor(private httpclient:HttpClient) { }

  public AddRole(Role:any){
    return this.httpclient.post(this.url+ 'AddRole' , Role);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public UpdateRole(Role:any){
    return this.httpclient.post(this.url+"UpdateRole",Role);
  }

  public GetById(role:any){
    return this.httpclient.post(this.url+"GetById",role);
  }
}
