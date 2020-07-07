import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { RouterModule } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [ShopComponent, ProductDetailComponent, ProductItemComponent],
  imports: [RouterModule, CommonModule, SharedModule, NgxSpinnerModule],
  exports: [ShopComponent],
})
export class ShoppingModule {}
