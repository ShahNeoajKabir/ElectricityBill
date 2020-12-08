import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SupportService {
  url="http://localhost:55109/api/Support/";

  constructor(private httpclient:HttpClient) { }

  public AddSupport(Support:any){
    return this.httpclient.post(this.url+'AddSupport', Support);
  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public Search(search:any){
    return this.httpclient.post(this.url+"SearchSupport",search);
  }

  public UpdateSupport(Support:any){
    return this.httpclient.post(this.url+"UpdateSupport",Support);

  }

  public GetById(Support:any){
    return this.httpclient.post(this.url+"GetById",Support);
  }

}
