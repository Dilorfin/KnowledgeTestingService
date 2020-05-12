import { TestBed } from '@angular/core/testing';

import { TestEditingService } from './test-editing.service';

describe('TestEditingService', () => {
  let service: TestEditingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestEditingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
