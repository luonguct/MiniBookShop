import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  busyRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) {}

  show() {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {
      bdColor: 'rgba(0,140,186,0.25)',
      size: 'medium',
      color: '#008cba',
      type: 'ball-clip-rotate',
    });
  }

  hide() {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide();
    }
  }
}
