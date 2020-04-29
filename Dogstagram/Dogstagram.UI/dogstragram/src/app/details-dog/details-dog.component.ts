import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DogService } from '../services/dog.service';
import { Dog } from '../Models/Dog';

@Component({
  selector: 'app-details-dog',
  templateUrl: './details-dog.component.html',
  styleUrls: ['./details-dog.component.css']
})
export class DetailsDogComponent implements OnInit {
  private id: string;
  private dog: Dog;

  constructor(private route: ActivatedRoute, private dogService: DogService) {
    this.route.params.subscribe(res => {
      //console.log(res["id"]);
      this.id = res['id'];
    });

    this.dogService.getDog(this.id).subscribe(res => {
      this.dog = res;
      //console.log(this.dog);
    });
  }

  ngOnInit(): void {
    console.log('Hi dude');
  }

}
