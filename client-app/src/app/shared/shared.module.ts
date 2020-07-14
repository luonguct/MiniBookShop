import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { PagerComponent } from './components/pager/pager.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [PagerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(), 
    RouterModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    PaginationModule,
    PagerComponent,
    ReactiveFormsModule,
    FormsModule
  ],
})
export class SharedModule {}
