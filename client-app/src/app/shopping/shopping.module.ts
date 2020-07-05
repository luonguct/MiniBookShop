import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailComponent } from './shop/product-detail/product-detail.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ShopComponent, ProductDetailComponent],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShoppingModule { }
