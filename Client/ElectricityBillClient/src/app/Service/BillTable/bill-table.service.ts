import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BillTableService {
  url="http://localhost:54667/api/Bill/";
  constructor(private httpclient:HttpClient) { }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
}
