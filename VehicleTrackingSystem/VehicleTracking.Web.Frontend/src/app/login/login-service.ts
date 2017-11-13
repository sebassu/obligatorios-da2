import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { environment } from '../../environments/environment';
import { RequestOptions, Request, RequestMethod } from '@angular/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import { LoginComponent } from './login.component';

@Injectable()
export class LoginService {

    private static LOGIN_URL: string = environment.APIURL + '/login';

    constructor(private _httpService: Http,
        private _router: Router) { }

    private successfulLogin(component: LoginComponent) {
        component.success = true;
        setTimeout(() => {
            this._router.navigateByUrl('/app');
        }, 2000);
    }

    private processLogin(username: string, response: Response, component: LoginComponent) {
        let responseData = response.json();
        localStorage.setItem("loggedUsername", username);
        localStorage.setItem("loggedUserRole", responseData["role"]);
        localStorage.setItem("token", responseData["access_token"]);
        this.successfulLogin(component);
    }

    private showError(error: Response, component: LoginComponent) {
        console.error(error);
        var message = error.json()["error_description"];
        if (!message) {
            message = "Error al establecerse una conexion con el servidor.";
        }
        component.errorMessage = message;
        component.errorOcurred = true;
        setTimeout(() => {
            component.errorOcurred = false;
        }, 3000);
    }

    attemptLoginWithData(username: string, password: string, component: LoginComponent): void {
        let header = new Headers({
            'Content-Type':
                'application/x-www-form-urlencoded'
        });
        let body = new URLSearchParams();
        body.set('grant_type', 'password');
        body.set('username', username);
        body.set('password', password);
        this._httpService.post(LoginService.LOGIN_URL, body.toString(),
            { 'headers': header }).map((response: Response) => {
                this.processLogin(username, response, component)
            }).subscribe(null, err => this.showError(err, component));
    }
}