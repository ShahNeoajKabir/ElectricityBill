import { Component, OnInit } from '@angular/core';
import { Notice } from 'src/app/Model/Notice';
import { NoticeService } from 'src/app/Service/Notice/notice.service';

@Component({
  selector: 'app-add-notice',
  templateUrl: './add-notice.component.html',
  styleUrls: ['./add-notice.component.css']
})
export class AddNoticeComponent implements OnInit {
  objNotice: Notice=new Notice();

  constructor(
    private NoticeService:NoticeService
  ) { }

  ngOnInit(): void {
  }
  AddNotice(){
    this.NoticeService.AddNotice(this.objNotice).subscribe((res:any)=>{
      console.log(res);
    })
  }

}
