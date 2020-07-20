import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'search-flight', pathMatch: 'prefix' },
      { path: 'search-flight', loadChildren: () => import('./search-flight/search-flight.module').then(m => m.SearchFlightModule) },
      { path: 'book-flight', loadChildren: () => import('./book-flight/book-flight.module').then(m => m.BookFlightModule) },
      { path: 'admin-flight', loadChildren: () => import('./admin-flight/admin-flight.module').then(m => m.AdminFlightModule) }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
