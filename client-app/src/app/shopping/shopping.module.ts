import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { RouterModule } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';

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
