import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { Payment } from './payment-details/payment.detail/payment.detail.component';
import { Payment } from './payment-details/payment.detail-list/payment.detail-list.component';

@NgModule({
  declarations: [
    AppComponent,
    PaymentDetailsComponent,
    Payment.DetailComponent,
    Payment.DetailListComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
