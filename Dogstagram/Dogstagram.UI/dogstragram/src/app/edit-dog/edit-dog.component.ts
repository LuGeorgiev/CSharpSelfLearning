import { Component, OnInit } from '@angular/core';
import { Dog } from '../Models/Dog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DogService } from '../services/dog.service';

@Component({
  selector: 'app-edit-dog',
  templateUrl: './edit-dog.component.html',
  styleUrls: ['./edit-dog.component.css']
})
export class EditDogComponent implements OnInit {
  dog: Dog;
  dogForm: FormGroup;
  dogId: string;

  constructor(private fb: FormBuilder,
    private rout: ActivatedRoute,
    private dogService: DogService,
    private router: Router) {
    this.dogForm = this.fb.group({
      'id': [''],
      'description': [''],
      'imageUrl':['']
    });
  }

  ngOnInit(): void {
    this.rout.params.subscribe(params => {
      this.dogId = params['id'];

      this.dogService.getDog(this.dogId).subscribe(data => {
        this.dog = data;

        this.dogForm = this.fb.group({
          'id': [this.dog.id],
          'description': [this.dog.description]
        });
      });

    });
  }

  editDog(){
    this.dogService.editDog(this.dogForm.value).subscribe(res =>{
      this.router.navigate(["dogs"])
    });
  }

}
