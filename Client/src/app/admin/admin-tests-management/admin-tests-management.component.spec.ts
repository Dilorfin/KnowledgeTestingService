import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTestsManagementComponent } from './admin-tests-management.component';

describe('AdminTestsManagementComponent', () => {
  let component: AdminTestsManagementComponent;
  let fixture: ComponentFixture<AdminTestsManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminTestsManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminTestsManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
