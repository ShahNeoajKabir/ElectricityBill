import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/Common/Auth/auth.service';
import { VMLogin } from 'src/app/Common/VMLogin';
import { SecurityService } from 'src/app/Service/Security/security.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  objlogin:VMLogin=new VMLogin();
  loginusertype:number=0;

  constructor(
    private sercurityservice:SecurityService,
    private router:Router,
    private activerouter:ActivatedRoute,
    private authservice:AuthService
    ) { }

  ngOnInit(): void {

  }
  LogIn () {
    // this.authservice.login(this.objlogin).
    this.authservice.login(this.objlogin).subscribe(res => {
      console.log(res);
      this.loginusertype=this.authservice.getLoggedUserType();

      // tslint:disable-next-line:triple-equals
        if (this.loginusertype === 1) {
        console.log(this.authservice.getLoggedUserType());

        this.router.navigate(['/Admin']);
        } else if(this.loginusertype === 2)
        {
          this.router.navigate(['/Co-Ordinator']);

        }else if(this.loginusertype === 4)
        {
          this.router.navigate(['/Co-Ordinator']);

        }

        console.log(res);

    });
  }

}
