import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ZoneAssignService {
  url="http://localhost:54667/api/ZoneAssign/";


  constructor(private httpclient:HttpClient) { }

  public AssignZone(ZoneAssign:any){
    return this.httpclient.post(this.url+"AssignZone",ZoneAssign);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public UpdateZoneAssign(ZoneAssign:any){
    return this.httpclient.post(this.url+"UpdateZoneAssign",ZoneAssign);
  }

  public GetById(ZoneAssign:any){
    return this.httpclient.post(this.url+"GetById",ZoneAssign);
  }

  public Search(Search:any){
    return this.httpclient.post(this.url+"Search",Search);
  }
}
