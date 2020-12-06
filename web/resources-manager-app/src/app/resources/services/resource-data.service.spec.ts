import { TestBed } from '@angular/core/testing';

import { ResourceDataService } from './resource-data.service';

describe('ResourceDataService', () => {
  let service: ResourceDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResourceDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
