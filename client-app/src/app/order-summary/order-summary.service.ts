import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderToCreate } from '../shared/models/order';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrderSummaryService {
  constructor(private http: HttpClient) {}

  creatOrder(order: OrderToCreate) {
    return this.http.post(`${environment.apiUrl}/order`, order);
  }
}
