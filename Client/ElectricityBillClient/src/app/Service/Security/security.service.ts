import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { VMLogin } from '../../Model/VMLogin';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  url="http://localhost:55109/api/Security/";

  constructor(private httpclient:HttpClient) { }

  public Login(obj:VMLogin)
  {
    return this.httpclient.post(this.url+'Login',obj);

  }
}
