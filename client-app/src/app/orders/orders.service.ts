import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { UserOrder, UserOrderDetail } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private http: HttpClient) { }

  getOrdersForUser() {
    return this.http.get<UserOrder[]>(`${environment.apiUrl}/order`);
  }

  getOrderByOrderId(id: number) {
    return this.http.get<UserOrderDetail>(`${environment.apiUrl}/order/` + id);
  }
}
