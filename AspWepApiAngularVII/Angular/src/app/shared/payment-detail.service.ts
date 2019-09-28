import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import {HttpClient}  from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})

export class PaymentDetailService {
  formData: PaymentDetail;
  readonly rootUrl = 'http://localhost:51562/api';
  list: PaymentDetail[];
  
  constructor(private http:HttpClient) { }

  postPaymentDetail(){
    return this.http.post(this.rootUrl + '/PaymentDetail',this.formData);
  }

  putPaymentDetail(){
    return this.http.put(this.rootUrl + '/PaymentDetail/'+ this.formData.PMId, this.formData);
  }

  deletePaymentDetail(id){
    return this.http.delete(this.rootUrl + '/PaymentDetail/'+ id);
  }

  refreshList(){
    this.http.get(this.rootUrl + '/PaymentDetail')
    .toPromise()
    .then(res=> this.list = res as PaymentDetail[])
  }
}
