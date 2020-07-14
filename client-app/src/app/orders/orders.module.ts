import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersComponent } from './orders.component';
import { SharedModule } from '../shared/shared.module';
import { OrderRoutingModule } from './orders-routing.module';
import { OrderDetailComponent } from './order-detail/order-detail.component';

@NgModule({
  declarations: [OrdersComponent, OrderDetailComponent],
  imports: [
    CommonModule,
    OrderRoutingModule,
    SharedModule
  ]
})
export class OrdersModule { }
