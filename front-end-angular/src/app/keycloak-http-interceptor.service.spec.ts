import { TestBed } from '@angular/core/testing';

import { KeycloakHttpInterceptor } from './keycloak-http-interceptor.service';

describe('KeycloakHttpInterceptorService', () => {
  let service: KeycloakHttpInterceptor;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KeycloakHttpInterceptor);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
