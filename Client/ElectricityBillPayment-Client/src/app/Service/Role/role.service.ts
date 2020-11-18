import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  url="https://localhost:44368/";

  constructor(private httpclient:HttpClient) { }

  public AddRole(Role:any){
    return this.httpclient.post(this.url+ 'AddRole' , Role);
  }
}
