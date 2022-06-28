import { TestBed } from '@angular/core/testing';

import { FormListenerService } from './form-listener.service';

describe('FormListenerService', () => {
  let service: FormListenerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FormListenerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
