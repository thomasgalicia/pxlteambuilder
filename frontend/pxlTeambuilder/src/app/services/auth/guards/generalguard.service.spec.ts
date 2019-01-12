import { TestBed } from '@angular/core/testing';

import { GeneralguardService } from './generalguard.service';

describe('GeneralguardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GeneralguardService = TestBed.get(GeneralguardService);
    expect(service).toBeTruthy();
  });
});
