import { v4 as uuid } from 'uuid';

export class Basket {
  id: string = uuid();
  items: BasketItem[] = [];
}

export class BasketItem {
  id: number;
  bookName: string;
  price: number;
  quantity: number;
  imageUrl: string;
  author: string;
  bookCategory: string;
}
