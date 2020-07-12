import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutSuccessComponent } from './checkout-success.component';
import { CheckoutSuccessRoutingModule } from './checkout-success-routing.module';

@NgModule({
  declarations: [CheckoutSuccessComponent],
  imports: [
    CommonModule,
    CheckoutSuccessRoutingModule
  ]
})
export class CheckoutSuccessModule { }
