import { Component, OnInit } from '@angular/core';
import { DogService } from '../services/dog.service';
import { Dog } from '../Models/Dog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-dogs',
  templateUrl: './list-dogs.component.html',
  styleUrls: ['./list-dogs.component.css']
})
export class ListDogsComponent implements OnInit {
  dogs: Array<Dog>;

  constructor(private dogService: DogService, private router: Router) { }

  ngOnInit(): void {
    this.dogService.getDogs().subscribe(dogs =>{
      this.dogs = dogs;
      //console.log(dogs)
    })
  }

  routeToDog(id){
    this.router.navigate(["dogs", id]);
  }
}
