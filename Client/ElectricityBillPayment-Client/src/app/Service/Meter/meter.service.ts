import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MeterService {
  url="http://localhost:55109/api/Meter/";

  constructor(private httpclient:HttpClient) { }

  public AddMeter(MeterTable:any){
    return this.httpclient.post(this.url+"AddMeter" , MeterTable);

  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");

  }
  public UpdateMeter(Meter:any){
    return this.httpclient.post(this.url+"UpdateMeter",Meter);
  }

  public GetById(Meter:any){
    return this.httpclient.post(this.url+"GetById",Meter);
  }

}
