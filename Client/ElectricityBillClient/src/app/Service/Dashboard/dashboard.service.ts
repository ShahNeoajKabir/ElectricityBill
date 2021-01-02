import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  url="https://localhost:44318/api/dashboard/";

  constructor(private httpclient:HttpClient) { }
  public GetDashboardData(){
    return this.httpclient.get(this.url+"GetDashboardData");
  }
  
}

