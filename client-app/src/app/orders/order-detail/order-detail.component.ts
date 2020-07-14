import { OrdersService } from './../orders.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserOrderDetail, UserOrderItemDetail } from '../../shared/models/order';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css']
})
export class OrderDetailComponent implements OnInit {
  order: UserOrderDetail;

  constructor(
    private orderService: OrdersService,
    private activateRoute: ActivatedRoute,
    ) { }

  ngOnInit(): void {
    this.loadOrderDetail();
  }

  loadOrderDetail() {
    this.orderService.getOrderByOrderId(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (order) => {
          this.order = order;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
