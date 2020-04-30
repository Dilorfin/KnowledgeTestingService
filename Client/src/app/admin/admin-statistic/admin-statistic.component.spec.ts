import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStatisticComponent } from './admin-statistic.component';

describe('AdminStatisticComponent', () => {
  let component: AdminStatisticComponent;
  let fixture: ComponentFixture<AdminStatisticComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminStatisticComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminStatisticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
