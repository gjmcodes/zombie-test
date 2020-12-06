import { TestBed } from '@angular/core/testing';

import { ResourceBuilderService } from './resource-builder.service';

describe('ResourceBuilderService', () => {
  let service: ResourceBuilderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResourceBuilderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
