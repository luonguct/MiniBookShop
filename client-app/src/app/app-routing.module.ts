import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShopComponent } from './shopping/shop.component';

const routes: Routes = [
    { path: '', component: ShopComponent  },
    { path: 'shop', loadChildren: () => import('./shopping/shopping.module').then(mod => mod.ShoppingModule) },  
    { path: 'about', loadChildren: () => import('./about/about.module').then(mod => mod.AboutModule) },
    { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
