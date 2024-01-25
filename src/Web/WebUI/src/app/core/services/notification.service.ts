import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  showSuccess(title: string, message: string) {
    Swal.fire({
      title: title,
      text: message,
      showConfirmButton: false,
      showCloseButton: true,
      timer: 3000,
      toast: true,
      position: 'top-end',
      customClass: {
          popup: 'notificacion-success',
      }
    });
  }

  showError(title: string, message: string) {
    Swal.fire({
      title: title,
      text: message,
      showConfirmButton: false,
      showCloseButton: true,
      timer: 3000,
      toast: true,
      position: 'top-end',
      customClass: {
          popup: 'notificacion-error'
      }
    });
  }
}
