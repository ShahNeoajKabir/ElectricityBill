import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from 'src/app/Common/Enum';
import { Utility } from 'src/app/Common/Utility';
import { Support } from 'src/app/Model/Support';
import { SupportService } from 'src/app/Service/Support/support.service';

@Component({
  selector: 'app-add-support',
  templateUrl: './add-support.component.html',
  styleUrls: ['./add-support.component.css']
})
export class AddSupportComponent implements OnInit {

  public objSupport:Support= new Support();
  public lststatus:any;

  public editsupport:Support=new Support();

  constructor(
    private supportservice:SupportService,
    private router:Router,
    private utility:Utility,
    private activeroute: ActivatedRoute

    ) { }

  ngOnInit(): void {
    this.lststatus=this.utility.enumToArray(Status);

    if (this.activeroute.snapshot.params['id'] !== undefined) {

      this.editsupport.SupportId = this.activeroute.snapshot.params['id' ];
      this.supportservice.GetById(this.editsupport).subscribe(( res: any) => {

        this.objSupport = res;
        console.log(this.objSupport);
     });
      console.log(this.activeroute.snapshot.params['id' ] );

    }

  }
  AddSupport(){
    console.log(this.objSupport);
    if (this.objSupport.SupportId > 0 ) {
      this.supportservice.UpdateSupport(this.objSupport).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Support/View']);
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.supportservice.AddSupport(this.objSupport).subscribe(res => {
        if (res === 1) {
          this.router.navigate(['/Support/View']);
          console.log(res);
        }
        console.log(res);
      } );

  }
}
}
