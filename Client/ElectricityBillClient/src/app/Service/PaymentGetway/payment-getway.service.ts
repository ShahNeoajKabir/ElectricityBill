import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaymentGetwayService {
  url="https://localhost:44318/api/PaymentGetway/";
  constructor(private httpclient:HttpClient) { }

  public GetCard(Card:any){
    return this.httpclient.post(this.url+"Card",Card)
  }
  public GetMobileBanking(Mobile:any){
    return this.httpclient.post(this.url+"MobileBanking",Mobile)
  }
}
