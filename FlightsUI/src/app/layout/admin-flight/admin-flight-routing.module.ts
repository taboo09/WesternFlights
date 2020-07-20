import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminFlightComponent } from './admin-flight.component';


const routes: Routes = [
  { path: '', component: AdminFlightComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminFlightRoutingModule { }
