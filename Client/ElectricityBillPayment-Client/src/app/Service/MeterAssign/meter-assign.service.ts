import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MeterAssignService {
  url="http://localhost:55109/api/AssignMeter/";


  constructor(private httpclient:HttpClient) { }

  public AssignMeter(Assign:any)
  {
    return this.httpclient.post(this.url+"AssignMeter",Assign);

  }

  public GEtAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
  public UpdateAssign(Assign:any){
    return this.httpclient.post(this.url+"UpdateAssign",Assign);
  }

  public GetById(Assign:any){
    return this.httpclient.post(this.url+"GetById",Assign);
  }
}
