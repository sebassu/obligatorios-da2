import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class IsNotLoggedGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let userIsNotLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("role") == null ||
            sessionStorage.getItem("token") == null;
        if (userIsNotLoggedIn) {
            return true;
        } else {
            this._router.navigate(['/app']);
            return false;
        }
    }
}