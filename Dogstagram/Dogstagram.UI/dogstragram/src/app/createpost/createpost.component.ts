import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DogService } from '../services/dog.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent {
  dogForm : FormGroup

  constructor(private fb:FormBuilder, private dogService: DogService) { 
    this.dogForm = this.fb.group({
      'ImageUrl': ['',Validators.required],
      'Description': ['']
    })
  }

  get imageUrl(){
    return this.dogForm.get('ImageUrl');
  }

  create(){
    this.dogService.create(this.dogForm.value).subscribe(res =>{
      console.log(res);
    })
  }
}
