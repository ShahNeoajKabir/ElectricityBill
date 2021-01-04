import { Injectable } from '@angular/core';
import Swal from 'sweetalert2/dist/sweetalert2.js';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  successNotification(){
    Swal.fire('Hi', 'Successfully save', 'success')
  }

  ErrorNotification(){
    Swal.fire('Hi', 'Data Not Save', 'error')
  }


}
