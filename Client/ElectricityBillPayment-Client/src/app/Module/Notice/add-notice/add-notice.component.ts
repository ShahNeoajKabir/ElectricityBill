import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { Notice } from 'src/app/Model/Notice';
import { NoticeService } from 'src/app/Service/Notice/notice.service';

@Component({
  selector: 'app-add-notice',
  templateUrl: './add-notice.component.html',
  styleUrls: ['./add-notice.component.css']
})
export class AddNoticeComponent implements OnInit {
   public objNotice: Notice=new Notice();
   public lstStatus:any;

  constructor(
    private NoticeService:NoticeService,private router:Router, private utility:Utility
  ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

  }
  AddNotice(){
    this.NoticeService.AddNotice(this.objNotice).subscribe((res:any)=>{
      console.log(res);
    })
  }

}
