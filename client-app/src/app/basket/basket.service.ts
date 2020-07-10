import { BasketTotal } from './../shared/models/basket';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Basket, BasketItem } from '../shared/models/basket';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Book } from '../shared/models/book';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private basketSource = new BehaviorSubject<Basket>(null);
  basket$ = this.basketSource.asObservable();

  private basketTotalSource = new BehaviorSubject<BasketTotal>(null);
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) {}

  getBasket(id: string) {
    return this.http.get<Basket>(`${environment.apiUrl}/basket?id=${id}`).pipe(
      map((basket: Basket) => {
        this.basketSource.next(basket);
        this.calculateTotals();
      })
    );
  }

  setBasket(basket: Basket) {
    return this.http
      .post<Basket>(`${environment.apiUrl}/basket`, basket)
      .subscribe(
        (response: Basket) => {
          this.basketSource.next(response);
          this.calculateTotals();
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: Book, quantity = 1) {
    const itemToAdd: BasketItem = this.mapBookItemToBasketItem(item, quantity);
    let basket = this.getCurrentBasketValue();
    if (basket === null) {
      basket = this.createBasket();
    }
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    console.log(basket);
    this.setBasket(basket);
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

  private addOrUpdateItem(
    items: BasketItem[],
    itemToAdd: BasketItem,
    quantity: number
  ): BasketItem[] {
    const index = items.findIndex((i) => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  private createBasket(): Basket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapBookItemToBasketItem(item: Book, quantity: number): BasketItem {
    return {
      id: item.bookId,
      bookName: item.title,
      price: item.price,
      imageUrl: item.imageUrl,
      quantity,
      author: item.author,
      bookCategory: item.bookCategory,
    };
  }
}
