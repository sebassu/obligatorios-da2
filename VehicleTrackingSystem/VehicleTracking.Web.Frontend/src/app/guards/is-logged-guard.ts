import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class IsLoggedGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let userIsLoggedIn = sessionStorage.getItem("username") != null &&
            sessionStorage.getItem("role") != null &&
            sessionStorage.getItem("token") != null;
        if (userIsLoggedIn) {
            return true;
        } else {
            this._router.navigate(['/login']);
            return false;
        }
    }
}