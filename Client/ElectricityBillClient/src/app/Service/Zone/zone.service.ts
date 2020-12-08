import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ZoneService {
  url="http://localhost:54667/api/Zone/";


  constructor(private httpclient:HttpClient) { }

  public AddZone(Zone:any){
    return this.httpclient.post(this.url+"AddZone", Zone );
  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public Search(search:any){
    return this.httpclient.post(this.url+"SearchZone",search);
  }

  public UpdateZone(zone:any){
    return this.httpclient.post(this.url+"UpdateZone",zone);
  }
  public GetById(zone:any){
    return this.httpclient.post(this.url+"GetById",zone);
  }
}
