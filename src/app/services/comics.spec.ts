import { TestBed } from '@angular/core/testing';

import { Comics } from './comics';

describe('Comics', () => {
  let service: Comics;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Comics);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
