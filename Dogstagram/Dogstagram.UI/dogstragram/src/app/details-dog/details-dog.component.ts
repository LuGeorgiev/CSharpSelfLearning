import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DogService } from '../services/dog.service';
import { Dog } from '../Models/Dog';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-details-dog',
  templateUrl: './details-dog.component.html',
  styleUrls: ['./details-dog.component.css']
})
export class DetailsDogComponent implements OnInit {
  private id: string;
  dog: Dog;

  constructor(private route: ActivatedRoute, private dogService: DogService) {
    // this.route.params.subscribe(res => {
    //   this.id = res['id'];

    //   this.dogService.getDog(this.id).subscribe(res => {
    //     this.dog = res;
    //   });
    // });
    this.fetchData();
  }

  fetchData(){
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id;
    }), mergeMap(id => this.dogService.getDog(id))).subscribe(res => {
      this.dog = res;
    })
  }

  ngOnInit(): void {
    console.log('Hi dude');
  }

}
