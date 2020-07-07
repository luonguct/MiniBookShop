import { Component, OnInit } from '@angular/core';
import { Book } from '../shared/models/book';
import { ShoppingService } from './shopping.service';
import { Author } from '../shared/models/author';
import { BookCategory } from '../shared/models/bookCategory';
import { ShopParams } from '../shared/models/ShopParams';
import { NgxSpinnerService } from 'ngx-spinner';

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

  constructor(
    private shoppingService: ShoppingService,
    private spinner: NgxSpinnerService
  ) {
    this.shopParams = this.shoppingService.getShopParams();
  }

  ngOnInit(): void {
    this.getBooks();
    this.getAuthors();
    this.getBookCategories();
  }

  getBooks() {
    this.spinner.show();
    this.shoppingService.getBooks().subscribe(
      (response) => {
        this.books = response.data;
        this.totalCount = response.count;
        this.spinner.hide();
      },
      (error) => {
        console.log(error);
        this.spinner.hide();
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

  onBookCategorySelected(bookCategoryId: number) {
    const params = this.shoppingService.getShopParams();
    params.bookCategoryId = bookCategoryId;
    params.pageIndex = 1;
    this.shoppingService.setShopParams(params);
    this.getBooks();
  }

  onPageChanged(event: any) {
    const params = this.shoppingService.getShopParams();
    if (params.pageIndex !== event) {
      params.pageIndex = event;
      this.shoppingService.setShopParams(params);
      this.getBooks();
    }
  }
}
