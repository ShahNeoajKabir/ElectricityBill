import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../Common/Auth/auth.service';
import { CustomerService } from '../../../Service/Customer/customer.service';

@Component({
  selector: 'app-customer-layout',
  templateUrl: './customer-layout.component.html',
  styleUrls: ['./customer-layout.component.css']
})
export class CustomerLayoutComponent implements OnInit {

  constructor(private customerservice:CustomerService, private router:Router,public authservice: AuthService) { }

  ngOnInit(): void {
  }

}
