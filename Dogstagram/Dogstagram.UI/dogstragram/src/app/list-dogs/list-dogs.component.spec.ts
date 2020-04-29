import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDogsComponent } from './list-dogs.component';

describe('ListDogsComponent', () => {
  let component: ListDogsComponent;
  let fixture: ComponentFixture<ListDogsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListDogsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListDogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
