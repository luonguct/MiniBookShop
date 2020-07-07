import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { RouterModule } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductItemComponent } from './product-item/product-item.component';


@NgModule({
  declarations: [ShopComponent, ProductDetailComponent, ProductItemComponent],
  imports: [
    RouterModule,
    CommonModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShoppingModule { }
