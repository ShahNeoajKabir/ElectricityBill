import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Utility } from 'src/app/Common/Utility';
import { Notice } from 'src/app/Model/Notice';
import { NoticeService } from 'src/app/Service/Notice/notice.service';

@Component({
  selector: 'app-list-notice',
  templateUrl: './list-notice.component.html',
  styleUrls: ['./list-notice.component.css']
})
export class ListNoticeComponent implements OnInit {
  public lstNotice:Notice[]= new Array<Notice>();


  constructor(private readonly noticeservice:NoticeService, private router:Router) { }

  ngOnInit(): void {
    this.noticeservice.GetAll().subscribe((res:any)=>{

      this.lstNotice=res;
      console.log(this.lstNotice);
    })

  }

}
