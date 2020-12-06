import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Support } from 'src/app/Model/Support';
import { SupportService } from 'src/app/Service/Support/support.service';

@Component({
  selector: 'app-list-support',
  templateUrl: './list-support.component.html',
  styleUrls: ['./list-support.component.css']
})
export class ListSupportComponent implements OnInit {

  public lstSupport:Support[]=new Array<Support>();
  public search:string="";

  constructor(
    private supportservice:SupportService,
    private router:Router,
    private activeroute:ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.supportservice.GetAll().subscribe((res:any)=>{
      this.lstSupport=res;
      console.log(this.lstSupport);

    })
  }

  Edit(id:any){
    console.log(id);
  }
  Search(){
    this.supportservice.Search(this.search).subscribe((res:any)=>{
      this.lstSupport=res;
      console.log(this.lstSupport);
    })
  }

}
