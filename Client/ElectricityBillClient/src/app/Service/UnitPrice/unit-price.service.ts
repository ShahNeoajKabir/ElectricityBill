import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UnitPriceService {
  url="https://localhost:44318/api/UnitPrice/";

  constructor(private httpclient:HttpClient,private router:Router) { }


  public AddUnitPrice(unitprice:any){
    return this.httpclient.post(this.url+"AddUnitPrice" , unitprice);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public GetById(User:any){
    return this.httpclient.post(this.url+"GetById",User);
  }
  public UpdateUnitPrice(UnitPrice:any){
    return this.httpclient.post(this.url+"UpdateUnitPrice",UnitPrice);
  }
}
