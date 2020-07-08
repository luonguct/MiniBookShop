import { Component, OnInit } from '@angular/core';
import { ShoppingService } from '../shopping.service';
import { Book } from '../../shared/models/book';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent implements OnInit {
  book: Book;
  constructor(
    private shoppingService: ShoppingService,
    private activateRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadBook();
  }

  loadBook() {
    this.shoppingService
      .getBook(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (book) => {
          this.book = book;
          console.log(this.book);
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
