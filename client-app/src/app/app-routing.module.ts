import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shopping/shop.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: 'shop', loadChildren: () => import('./shopping/shopping.module').then(mod => mod.ShoppingModule) },
  { path: 'about', loadChildren: () => import('./about/about.module').then(mod => mod.AboutModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  { path: 'checkout', canActivate: [AuthGuard], loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },

  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
