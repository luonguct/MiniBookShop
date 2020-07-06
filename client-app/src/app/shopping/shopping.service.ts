import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pagination } from '../shared/models/pagination';
import { Book } from '../shared/models/book';



@Injectable({
  providedIn: 'root'
})
export class ShoppingService {

  constructor(private http: HttpClient) {}

  getProducts() {
    return this.http.get<Pagination<Book>>(`${environment.apiUrl}/book`);
  }
}
