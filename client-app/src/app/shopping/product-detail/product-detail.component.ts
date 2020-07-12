import { Component, OnInit } from '@angular/core';
import { ShoppingService } from '../shopping.service';
import { Book } from '../../shared/models/book';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  book: Book;
  quantity = 1;

  constructor(
    private shoppingService: ShoppingService,
    private activateRoute: ActivatedRoute,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.loadBook();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.book, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  loadBook() {
    this.shoppingService
      .getBook(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (book) => {
          this.book = book;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
