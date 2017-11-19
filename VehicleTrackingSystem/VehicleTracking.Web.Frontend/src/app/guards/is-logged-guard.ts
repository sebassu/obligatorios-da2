import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class IsLoggedGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let redirectToLogin = sessionStorage.getItem("loggedUsername") === null ||
            sessionStorage.getItem("loggedUserRole") === null;
        if (redirectToLogin) {
            this._router.navigate(['/login']);
            return false;
        };
        return true;
    }
}