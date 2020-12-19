import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CardService {
  url="https://localhost:44318/api/Card/";
  constructor(private httpclient:HttpClient) { }


  public AddCard(Card:any){
    return this.httpclient.post(this.url+"AddCard",Card)
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public GetById(Card:any){
    return this.httpclient.post(this.url+"GetById",Card);
  }
}
