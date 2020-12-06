import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Notice } from '../../../Model/Notice';
import { NoticeService } from '../../../Service/Notice/notice.service';

@Component({
  selector: 'app-list-notice',
  templateUrl: './list-notice.component.html',
  styleUrls: ['./list-notice.component.css']
})
export class ListNoticeComponent implements OnInit {
  public lstNotice:Notice[]= new Array<Notice>();
  public search:string="";


  constructor(private readonly noticeservice:NoticeService, private router:Router) { }

  ngOnInit(): void {
    this.noticeservice.GetAll().subscribe((res:any)=>{

      this.lstNotice=res;
      console.log(this.lstNotice);
    })

  }
  Edit(id: any) {

    console.log(id);
  }
  Search(){
    this.noticeservice.Search(this.search).subscribe((res:any)=>{
      this.lstNotice=res;
      console.log(this.lstNotice);
    })
  }

}
