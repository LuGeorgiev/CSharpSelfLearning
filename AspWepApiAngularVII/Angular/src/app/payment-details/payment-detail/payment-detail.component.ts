import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private service:PaymentDetailService) {
    
  }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form!=null)
    form.reset();

    this.service.formData = {
      PMId : 0,
      CardNumber:'',
      CardOwnerName:'',
      ExpirationDate:'',
      CVV:''
    }
  }

  onSubmit(form:NgForm){
   this.service.postPaymentDetail(form.value)
    .subscribe(
      res=>{
        //If successfull we reset the form
        this.resetForm(form);
      },
      err=>{
        console.log(err);
      }
    );
  }
}
