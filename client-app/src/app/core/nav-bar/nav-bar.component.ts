import { BasketService } from './../../basket/basket.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Basket } from '../../shared/models/basket';
import { User } from '../../shared/models/user';
import { AccountService } from '../../account/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  basket$: Observable<Basket>
  currentUser$: Observable<User>;

  constructor(private basketService:BasketService, private accountService:AccountService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$;

    console.log(this.basket$);
  }

  logout() {
    this.accountService.logout();
  }
}
