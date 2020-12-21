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
  public ViewProfile(obj:any){
    return this.httpclient.post(this.url+"Profile",obj);
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
}
