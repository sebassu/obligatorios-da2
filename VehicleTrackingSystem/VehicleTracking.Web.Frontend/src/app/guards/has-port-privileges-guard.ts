import { CanActivate, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class HasPortPrivilegesGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        } else {
            return this.validateUserHasPrivileges();
        }
    }

    private validateUserHasPrivileges(): boolean {
        let userRole = sessionStorage.getItem("role");
        let isInvalidUserRole = userRole !== environment.ADMINISTRATOR_ROLE
            && userRole !== environment.PORT_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        } else {
            return true;
        }
    }
}