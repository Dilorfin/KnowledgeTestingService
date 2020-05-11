import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EndAttemptComponent } from './end-attempt.component';

describe('EndAttemptComponent', () => {
  let component: EndAttemptComponent;
  let fixture: ComponentFixture<EndAttemptComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EndAttemptComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EndAttemptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
