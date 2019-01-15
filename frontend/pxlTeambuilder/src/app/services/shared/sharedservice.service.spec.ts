import { TestBed } from '@angular/core/testing';

import { SharedService } from './sharedservice.service';

describe('SharedserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SharedService = TestBed.get(SharedService);
    expect(service).toBeTruthy();
  });
});
