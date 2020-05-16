import { TestBed } from '@angular/core/testing';

import { AdminStatisticService } from './admin-statistic.service';

describe('AdminStatisticService', () => {
  let service: AdminStatisticService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminStatisticService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
