import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {URL} from '../../../Model/URL'
import { RolePermissionService } from '../../../Service/RolePermission/role-permission.service';

@Component({
  selector: 'app-add-url',
  templateUrl: './add-url.component.html',
  styleUrls: ['./add-url.component.css']
})
export class AddUrlComponent implements OnInit {
  public objurl:URL=new URL();

  constructor(private rolepermissionservice:RolePermissionService,private router:Router,private ActivateRouter:ActivatedRoute) { }

  ngOnInit(): void {
  }

  AddUrl(){
    this.rolepermissionservice.AddUrl(this.objurl).subscribe(res=>{
      console.log(res);
    })
  }

}
