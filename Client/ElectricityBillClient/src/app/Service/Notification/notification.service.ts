import { Injectable } from '@angular/core';
import Swal from 'sweetalert2/dist/sweetalert2.js';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  successNotification(massage:string){
    Swal.fire(massage);
  }
  updateNotification(updatemassage:string){
    Swal.fire(updatemassage);
  }

  ErrorNotification(errormassage:string){
    Swal.fire(errormassage);
  }


}
