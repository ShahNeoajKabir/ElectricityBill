import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  url="http://localhost:54667/api/Customer/";

  constructor(private httpclient:HttpClient) { }

  public AddCustomer(obj:any){
    return this.httpclient.post(this.url+"Registration",obj);
  }

  public GetById(Customer:any){
    return this.httpclient.post(this.url+"GetbyID",Customer);
  }

  public Search(search:any){
    return this.httpclient.post(this.url+"SearchCustomer",search);
  }
  public UpdateUser(Custome:any){
    return this.httpclient.post(this.url+"UpdateCustomer",Custome);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public GetAlll(){
    return this.httpclient.get(this.url+"GetAlll");
  }
}
