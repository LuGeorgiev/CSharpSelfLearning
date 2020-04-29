import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsDogComponent } from './details-dog.component';

describe('DetailsDogComponent', () => {
  let component: DetailsDogComponent;
  let fixture: ComponentFixture<DetailsDogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsDogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsDogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
