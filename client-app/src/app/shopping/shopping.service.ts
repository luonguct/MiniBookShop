import { BookCategory } from './../shared/models/bookCategory';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pagination } from '../shared/models/pagination';
import { Book } from '../shared/models/book';
import { Author } from '../shared/models/author';
import { ShopParams } from '../shared/models/ShopParams';
import { map, delay } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ShoppingService {
  books: Book[] = [];
  pagination = new Pagination<Book>();
  shopParams = new ShopParams();

  constructor(private http: HttpClient) {}

  getBooks() {
    let params = new HttpParams();

    if (this.shopParams.authorId !== 0) {
      params = params.append('authorId', this.shopParams.authorId.toString());
    }

    if (this.shopParams.bookCategoryId !== 0) {
      params = params.append(
        'bookCategoryId',
        this.shopParams.bookCategoryId.toString()
      );
    }

    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }

    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageIndex.toString());
    params = params.append('pageSize', this.shopParams.pageSize.toString());

    return this.http
      .get<Pagination<Book>>(`${environment.apiUrl}/book`, {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          this.books = [...this.books, ...response.body.data];
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getBook(id: number) {
    // const product = this.books.find(p => p.bookId === id);

    // if (product) {
    //   return of(product);
    // }

    return this.http.get<Book>(`${environment.apiUrl}/book/` + id);
  }

  getAuthors() {
    return this.http.get<Author[]>(`${environment.apiUrl}/author`);
  }

  getBookCategories() {
    return this.http.get<BookCategory[]>(`${environment.apiUrl}/bookCategory`);
  }

  getShopParams() {
    return this.shopParams;
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }
}
