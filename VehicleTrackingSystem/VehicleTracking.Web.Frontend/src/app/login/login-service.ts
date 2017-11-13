import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { environment } from '../../environments/environment';
import { RequestOptions, Request, RequestMethod } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/map';

@Injectable()
export class LoginService {

    private errorMessage: string;
    private static LOGIN_URL: string = environment.APIURL + '/login';

    constructor(private _httpService: Http,
        private _currentRoute: ActivatedRoute,
        private _router: Router) { }

    private processLogin(username: string, response: Response) {
        localStorage.setItem("loggedUsername", username);
        localStorage.setItem("loggedUserRole", response.json()["role"]);
        this.errorMessage = null;
        return true;
    }

    naviagateHome() {
        this._router.navigate(['/home']);
    }

    private recordError(error: Response) {
        console.error(error);
        var message = error.json()["error_description"];
        if (message) {
            this.errorMessage = message;
        } else {
            this.errorMessage = "Error al establecerse una conexion con el servidor.";
        }
    }

    private handlePossibleError() {
        if (this.errorMessage !== null) {
            throw new Error(this.errorMessage);
        }
    }

    attemptLoginWithData(username: string, password: string): void {
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
                this.processLogin(username, response)
            }).subscribe(null, err => this.recordError(err));
        this.handlePossibleError();
    }
}