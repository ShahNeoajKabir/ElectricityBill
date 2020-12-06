import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Notice } from '../../../Model/Notice';
import { NoticeService } from '../../../Service/Notice/notice.service';

@Component({
  selector: 'app-add-notice',
  templateUrl: './add-notice.component.html',
  styleUrls: ['./add-notice.component.css']
})
export class AddNoticeComponent implements OnInit {
   public objNotice: Notice=new Notice();
   public lstStatus:any;
   public editnotice:Notice=new Notice();

  constructor
  (
    private NoticeService:NoticeService,
    private router:Router,
    private utility:Utility,
    private ActivateRouter:ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editnotice.NoticeId = this.ActivateRouter.snapshot.params['id' ];
      this.NoticeService.GetById(this.editnotice).subscribe(( res: any) => {

        this.objNotice = res;
        console.log(this.objNotice);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }

  }
  AddNotice(){
    console.log(this.objNotice);
    if (this.objNotice.NoticeId > 0 ) {
      this.NoticeService.UpdateNotice(this.objNotice).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Notice/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.NoticeService.AddNotice(this.objNotice).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Notice/View']);
          console.log(res);
        }
        console.log(res);
      } );
    }
  }

}
