import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer.component';
import { MatDividerModule } from '@angular/material/divider';

@NgModule({
  declarations: [FooterComponent],
  imports: [
    CommonModule,
    MatDividerModule
  ],
  exports: [
    FooterComponent
  ]
})
export class FooterModule { }
