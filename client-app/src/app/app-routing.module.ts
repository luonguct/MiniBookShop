import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shopping/shop.component';
import { ProductDetailComponent } from './shopping/product-detail/product-detail.component';
import { AboutComponent } from './about/about.component';


const routes: Routes = [
    { path: '', component: ShopComponent  },
    { path: 'shop', component: ShopComponent },
    { path: 'shop/:id', component: ProductDetailComponent },
    { path: 'about', component: AboutComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
