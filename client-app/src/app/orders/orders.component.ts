import { UserOrder, UserOrderDetail } from './../shared/models/order';
import { Component, OnInit } from '@angular/core';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: UserOrder[];

  constructor(private ordersService: OrdersService) { }

  ngOnInit() {
    this.getOrders();
  }

  getOrders() {
    this.ordersService.getOrdersForUser().subscribe((ord: UserOrder[]) => {
      this.orders = ord;
    }, error => {
      console.log(error);
    });
  }
}
