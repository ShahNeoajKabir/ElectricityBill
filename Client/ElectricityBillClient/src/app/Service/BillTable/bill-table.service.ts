import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BillTableService {
  url="https://localhost:44318/api/Bill/";
  constructor(private httpclient:HttpClient) { }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public GetById(Bill:any){
    return this.httpclient.post(this.url+"GetById",Bill);
  }
}
