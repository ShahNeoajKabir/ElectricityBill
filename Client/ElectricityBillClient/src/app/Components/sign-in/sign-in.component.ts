import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Common/Auth/auth.service';
import { VMLogin } from '../../Model/VMLogin';
import { SecurityService } from '../../Service/Security/security.service';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  public objLogin: VMLogin = new VMLogin();
  

  constructor(private Securityservice: SecurityService, private router: Router, private authservice: AuthService) { }

  ngOnInit() {
  }

  Login() {
    this.authservice.login(this.objLogin).subscribe(res => {

      // tslint:disable-next-line:triple-equals
        if (this.authservice.getLoggedUserType() === 4) {
        console.log(this.authservice.getLoggedUserType());

        this.router.navigate(['/CustomerDashboard/Profile']);
        } else {
          this.router.navigate(['/dashboard']);

        }

        console.log(res);

    });
  }

}
