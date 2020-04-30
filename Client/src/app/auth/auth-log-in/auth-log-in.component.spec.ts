import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthLogInComponent } from './auth-log-in.component';

describe('AuthLogInComponent', () => {
  let component: AuthLogInComponent;
  let fixture: ComponentFixture<AuthLogInComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthLogInComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthLogInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
