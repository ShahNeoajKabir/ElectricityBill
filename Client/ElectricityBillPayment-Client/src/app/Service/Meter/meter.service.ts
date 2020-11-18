import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MeterService {
  url="https://localhost:44368/api/Zone/";

  constructor(private httpclient:HttpClient) { }

  public AddMeter(MeterTable:any){
    return this.httpclient.post(this.url+"AddMeter" , MeterTable);

  }
}
