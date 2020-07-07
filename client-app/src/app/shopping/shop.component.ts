import { Component, OnInit } from '@angular/core';
import { Book } from '../shared/models/book';
import { ShoppingService } from './shopping.service';
import { Author } from '../shared/models/author';
import { BookCategory } from '../shared/models/bookCategory';
import { ShopParams } from '../shared/models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  books: Book[];
  authors: Author[];
  bookCategories: BookCategory[];

  shopParams: ShopParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  constructor(private shoppingService: ShoppingService) {}

  ngOnInit(): void {
    this.getBooks();
    this.getAuthors();
    this.getBookCategories();
  }

  getBooks() {
    this.shoppingService.getBooks().subscribe(
      (response) => {
        this.books = response.data;
        console.log(this.books);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getAuthors() {
    this.shoppingService.getAuthors().subscribe(
      (response) => {
        this.authors = response;
        console.log(this.authors);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBookCategories() {
    this.shoppingService.getBookCategories().subscribe(
      (response) => {
        this.bookCategories = [{ bookCategoryId: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onSortSelected(sort: string) {
    const params = this.shoppingService.getShopParams();
    params.sort = sort;
    this.shoppingService.setShopParams(params);
    this.getBooks();
  }
}
