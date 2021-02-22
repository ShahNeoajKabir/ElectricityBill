import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  url="https://localhost:44318/api/Customer/";

  constructor(private httpclient:HttpClient) { }

  public AddCustomer(obj:any){
    return this.httpclient.post(this.url+"Registration",obj);
  }
  public ViewProfile(){
    return this.httpclient.get(this.url+"Profile");
  }
  public ViewBillPaper(){
    return this.httpclient.get(this.url+"ViewBillPaper");
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
  public GetAllPendingCustomer(){
    return this.httpclient.get(this.url+"GetAllPendingCustomer");
  }
  public GetAllPending(){
    return this.httpclient.get(this.url+"GetAllPending");
  }
  public GetAllCustomerLocation(){
    return this.httpclient.get(this.url+"GetCustomerLocation");
  }
  
  
}
