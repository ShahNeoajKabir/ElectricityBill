import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RolePermissionService {
  url="https://localhost:44318/api/RolePermission/";


  constructor(private httpclient:HttpClient) { }

  public AddUrl(URLl:any){
    return this.httpclient.post(this.url+ 'AddURL' , URLl);
  }
}
