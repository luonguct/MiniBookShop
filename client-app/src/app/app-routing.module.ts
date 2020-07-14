import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shopping/shop.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: 'shop', loadChildren: () => import('./shopping/shopping.module').then(mod => mod.ShoppingModule) },
  { path: 'about', loadChildren: () => import('./about/about.module').then(mod => mod.AboutModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: 'order-summary',canActivate: [AuthGuard], loadChildren: () => import('./order-summary/order-summary.module').then(mod => mod.OrderSummaryModule) },
  { path: 'checkout-success',canActivate: [AuthGuard], loadChildren: () => import('./checkout-success/checkout-success.module').then(mod => mod.CheckoutSuccessModule) },
  { path: 'orders',canActivate: [AuthGuard], loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule) },

  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
