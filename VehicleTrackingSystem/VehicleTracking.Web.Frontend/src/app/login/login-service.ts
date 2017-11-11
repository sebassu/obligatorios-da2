import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { environment } from '../../environments/environment';
import { RequestOptions, Request, RequestMethod } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class LoginService {

    private hideErrorAlert: boolean = true;
    private static LOGIN_URL: string = environment.APIURL + '/login';

    constructor(private _httpService: Http) { }

    private processLogin(username: string, password: string) {
        alert("Usuario" + username + "logueado.");
    }

    private handleError(error: Response) {
        alert(error.json()["error_description"]);
        console.error(error);
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
                this.processLogin(username, password)
            }).subscribe(null, err => this.handleError(err));
    }
}