import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MobileBankingService {
  url="http://localhost:54667/api/MobileBanking/";
  constructor(private htppclient:HttpClient) { }

  public AddMobile(Mobile:any){
    return this.htppclient.post(this.url+"AddMobile",Mobile);
  }


  public GetAll(){
    return this.htppclient.get(this.url+"GetAll");
  }

  public GetById(Mobile:any){
    return this.htppclient.post(this.url+"GetById",Mobile);
  }
}
