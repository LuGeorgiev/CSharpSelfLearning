import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDogComponent } from './edit-dog.component';

describe('EditDogComponent', () => {
  let component: EditDogComponent;
  let fixture: ComponentFixture<EditDogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditDogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditDogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
