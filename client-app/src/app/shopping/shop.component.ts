import { Component, OnInit } from '@angular/core';
import { Book } from '../shared/models/book';
import { ShoppingService } from './shopping.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  books: Book[];
  constructor(private shoppingService: ShoppingService) { }

  ngOnInit(): void {
    this.shoppingService.getProducts().subscribe(response => {
      this.books = response.data;
      console.log(this.books);
    }, error => {
      console.log(error);
    });
  }

}
