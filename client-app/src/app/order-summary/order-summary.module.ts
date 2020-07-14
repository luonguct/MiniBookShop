import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderSummaryComponent } from './order-summary.component';
import { OrderSummaryRoutingModule } from './order-summary-routing.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [OrderSummaryComponent],
  imports: [
    CommonModule,
    OrderSummaryRoutingModule,
    SharedModule
  ]
})
export class OrderSummaryModule { }
