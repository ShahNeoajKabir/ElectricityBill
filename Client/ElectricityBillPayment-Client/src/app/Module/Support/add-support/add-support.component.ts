import { Component, OnInit } from '@angular/core';
import { Support } from 'src/app/Model/Support';
import { SupportService } from 'src/app/Service/Support/support.service';

@Component({
  selector: 'app-add-support',
  templateUrl: './add-support.component.html',
  styleUrls: ['./add-support.component.css']
})
export class AddSupportComponent implements OnInit {

  objSupport:Support= new Support();

  constructor( private supportservice:SupportService) { }

  ngOnInit(): void {
  }
  AddSupport(){
    this.supportservice.AddSupport(this.objSupport).subscribe((res:any)=>{
      console.log(res);
    })

  }

}
