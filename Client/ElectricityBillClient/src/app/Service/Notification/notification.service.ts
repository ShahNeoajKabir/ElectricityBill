import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2/dist/sweetalert2.js';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  successNotification(){
    Swal.fire("Data Added successfully !!");
  }
  
  updateNotification(){
    Swal.fire("Data Updated successfully !!");
  }

  ErrorNotification(){
    Swal.fire("Something is wrong !! Please Try Again");
  }
  Massagereply(message:string){
    Swal.fire(message);
  }
 


}
