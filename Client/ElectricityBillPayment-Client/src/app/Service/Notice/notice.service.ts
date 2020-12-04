import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NoticeService {
  url="http://localhost:55109/api/Notice/";


  constructor(
    private httpclient:HttpClient
  ) { }
  public AddNotice(Notice:any){
    return this.httpclient.post(this.url+'AddNotice', Notice);

  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public UpdateNotice(Notice:any){
    return this.httpclient.post(this.url+"UpdateNotice",Notice);
  }

  public GetById(notice:any){
    return this.httpclient.post(this.url+"GetById",notice);
  }
}
