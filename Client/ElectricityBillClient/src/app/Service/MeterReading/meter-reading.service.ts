import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MeterReadingService {

  url="https://localhost:44318/api/MeterReading/";


  constructor(
    private httpclient:HttpClient
  ) { }
  public AddMeterReading(MeterReading:any){
    return this.httpclient.post(this.url+'AddMeterReading', MeterReading);

  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  // public Search(search:any){
  //   return this.httpclient.post(this.url+"SearchNotice",search);
  // }
  public UpdateMeterReading(MeterReading:any){
    return this.httpclient.post(this.url+"UpdateMeterReading",MeterReading);
  }

  public GetById(MeterReading:any){
    return this.httpclient.post(this.url+"GetById",MeterReading);
  }
}
