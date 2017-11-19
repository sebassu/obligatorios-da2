import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class IsNotLoggedGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let redirectToHome = sessionStorage.getItem("loggedUsername") !== null &&
            sessionStorage.getItem("loggedUserRole") !== null;
        if (redirectToHome) {
            this._router.navigate(['/app']);
            return false;
        };
        return true;
    }
}