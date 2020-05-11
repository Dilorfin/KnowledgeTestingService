import { TestBed } from '@angular/core/testing';

import { TestPassingService } from './test-passing.service';

describe('TestPassingService', () => {
  let service: TestPassingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestPassingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
