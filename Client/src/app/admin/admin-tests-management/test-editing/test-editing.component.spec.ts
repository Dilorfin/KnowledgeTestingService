import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestEditingComponent } from './test-editing.component';

describe('TestEditingComponent', () => {
  let component: TestEditingComponent;
  let fixture: ComponentFixture<TestEditingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestEditingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestEditingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
