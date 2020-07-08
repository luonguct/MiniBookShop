import { Author } from './../shared/models/author';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Book } from '../shared/models/book';
import { ShoppingService } from './shopping.service';
import { BookCategory } from '../shared/models/bookCategory';
import { ShopParams } from '../shared/models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  books: Book[];
  authors: Author[];
  bookCategories: BookCategory[];
  bookCategoryTitle: string;

  shopParams: ShopParams;
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  constructor(
    private shoppingService: ShoppingService
  ) {
    this.shopParams = this.shoppingService.getShopParams();
  }

  ngOnInit(): void {
    this.getBooks();
    this.getAuthors();
    this.getBookCategories();
  }

  getBooks() {
    const params = this.shoppingService.getShopParams();
    this.shoppingService.getBooks().subscribe(
      (response) => {
        this.bookCategoryTitle = params.bookCategoryTitle;
        this.books = response.data;
        this.totalCount = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getAuthors() {
    this.shoppingService.getAuthors().subscribe(
      (response) => {
        this.authors = [{ authorId: 0, name: 'All' }, ...response];;
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

  onBookCategorySelected(bookCategoryId: number, bookCategoryTitle: string) {
    const params = this.shoppingService.getShopParams();
    params.bookCategoryId = bookCategoryId;
    params.bookCategoryTitle = bookCategoryTitle;
    params.pageIndex = 1;
    this.shoppingService.setShopParams(params);
    this.getBooks();
  }

  onAuthorSelected(authorId: number) {
    const params = this.shoppingService.getShopParams();
    params.authorId = authorId;
    params.pageIndex = 1;
    this.shoppingService.setShopParams(params);
  }

  onPageChanged(event: any) {
    const params = this.shoppingService.getShopParams();
    if (params.pageIndex !== event) {
      params.pageIndex = event;
      this.shoppingService.setShopParams(params);
      this.getBooks();
    }
  }

  onSearch() {
    const params = this.shoppingService.getShopParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageIndex = 1;
    this.shoppingService.setShopParams(params);
    this.getBooks();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.shoppingService.setShopParams(this.shopParams);
    this.getBooks();
  }
}
