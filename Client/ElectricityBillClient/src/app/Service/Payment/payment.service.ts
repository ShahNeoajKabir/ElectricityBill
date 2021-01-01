import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  url="https://localhost:44318/api/Payment/";

  constructor(private httpclient:HttpClient) { }

  public GetPayment(BillId:any){
    return this.httpclient.post(this.url+"GetPayment",BillId);

  }
  public MakePayment(BillId:any){
    return this.httpclient.post(this.url+"MakePayment",BillId);

  }
}
