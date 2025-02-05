import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { AuthGuard } from './auth.guard';

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let routerMock = { navigate: jasmine.createSpy('navigate') }; // Mock para Router

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        AuthGuard,
        { provide: Router, useValue: routerMock } // Inyectar Router falso para evitar errores
      ]
    });

    guard = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });

  it('should allow activation if token is valid', () => {
    spyOn(localStorage, 'getItem').and.returnValue('valid-token');
    spyOn<any>(guard, 'isTokenExpired').and.returnValue(false);

    expect(guard.canActivate()).toBeTrue();
  });

  it('should block activation if token is missing', () => {
    spyOn(localStorage, 'getItem').and.returnValue(null);

    expect(guard.canActivate()).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });

  it('should block activation if token is expired', () => {
    spyOn(localStorage, 'getItem').and.returnValue('expired-token');
    spyOn<any>(guard, 'isTokenExpired').and.returnValue(true);

    expect(guard.canActivate()).toBeFalse();
    expect(routerMock.navigate).toHaveBeenCalledWith(['/login']);
  });
});
