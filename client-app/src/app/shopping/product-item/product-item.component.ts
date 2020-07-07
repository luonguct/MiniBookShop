import { Book } from './../../shared/models/book';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() book: Book

  constructor() { }

  ngOnInit(): void {
  }

}
