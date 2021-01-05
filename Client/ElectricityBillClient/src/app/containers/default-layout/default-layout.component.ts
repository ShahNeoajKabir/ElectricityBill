import {Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Common/Auth/auth.service';
import { navItems, navItemsCoOrdinators } from '../../_nav';
import { navItemsMeterReader } from '../../_nav';


@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent implements OnInit {
  public sidebarMinimized = false;
  public navItems = navItems;
  public navItemsMeterReaders = navItemsMeterReader;
  public navItemsCoOrdinators = navItemsCoOrdinators;


  public roleId:any;
  constructor( private router:Router,public authservice: AuthService) { }
  toggleMinimize(e) {
    this.sidebarMinimized = e;
    this.roleId=this.authservice.getUserRole();

    

  }
  ngOnInit(): void {
    this.roleId=this.authservice.getUserRole();
    console.log(this.roleId);
  }
}
