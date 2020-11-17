import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NoticeService {
  url="https://localhost:44368/";


  constructor(
    private httpclient:HttpClient
  ) { }
  public AddNotice(Notice:any){
    return this.httpclient.post(this.url+'AddNotice', Notice);

  }
}
