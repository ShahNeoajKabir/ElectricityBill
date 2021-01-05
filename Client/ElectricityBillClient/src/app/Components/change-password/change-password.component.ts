import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Common/Auth/auth.service';
import { VMChangePassword } from '../../Model/VMChangePassword';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  public objvmpass:VMChangePassword=new VMChangePassword();

  constructor(private authservice:AuthService) { }

  ngOnInit(): void {
    this.objvmpass.Email=this.authservice.getLoggedEmail();
    this.objvmpass.UserId=this.authservice.getLoggedUserId();
  }

}
