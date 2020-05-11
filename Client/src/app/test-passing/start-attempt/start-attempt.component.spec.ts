import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartAttemptComponent } from './start-attempt.component';

describe('StartAttemptComponent', () => {
  let component: StartAttemptComponent;
  let fixture: ComponentFixture<StartAttemptComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartAttemptComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartAttemptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
