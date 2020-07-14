import { OrderSummaryService } from './order-summary.service';
import { OrderToCreate } from './../shared/models/order';
import { BasketService } from './../basket/basket.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../shared/models/user';
import { AccountService } from '../account/account.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Basket, BasketTotal } from '../shared/models/basket';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.css'],
})
export class OrderSummaryComponent implements OnInit {
  basket$: Observable<Basket>;
  basketTotal$: Observable<BasketTotal>;
  currentUser$: Observable<User>;
  email: string;
  displayName: string;
  orderForm: FormGroup;

  constructor(
    private basketService: BasketService,
    private accountService: AccountService,
    private orderSummaryService:OrderSummaryService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.basketTotal$ = this.basketService.basketTotal$;
    this.createOrderForm();
    this.loadCurrentUserInfo();
  }

  loadCurrentUserInfo() {
    this.accountService.currentUser$.subscribe((user) => {
      this.orderForm.patchValue({
        email: user.email,
        displayName: user.displayName,
      });
    });
  }

  createOrderForm() {
    this.orderForm = new FormGroup({
      email: new FormControl(),
      displayName: new FormControl(),
      firstName: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
      address: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
      province: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
      zipCode: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
      ]),
    });
  }

  async submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    var order:OrderToCreate = this.orderForm.value;
    order.basketId = basket.id;

    this.orderSummaryService.creatOrder(order).subscribe(
      () => {
        this.basketService.deleteBasket(basket);
        this.router.navigate(['checkout-success']);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
