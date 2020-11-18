import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ZoneService {
  url="https://localhost:44368/api/Zone/";

  constructor(private httpclient:HttpClient) { }

  public AddZone(Zone:any){
    return this.httpclient.post(this.url+"AddZone", Zone );
  }
}
