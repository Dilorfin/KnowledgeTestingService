import { TestBed } from '@angular/core/testing';

import { AdminUsersManagementService } from './admin-users-management.service';

describe('AdminUsersManagementService', () => {
  let service: AdminUsersManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminUsersManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
