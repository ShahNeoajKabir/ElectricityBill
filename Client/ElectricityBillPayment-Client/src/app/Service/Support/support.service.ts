import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SupportService {
  url="https://localhost:44368/api/Support/";

  constructor(private httpclient:HttpClient) { }

  public AddSupport(Support:any){
    return this.httpclient.post(this.url+'AddSupport', Support);

  }
}
