import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

@Injectable()
export class BaseService {

    constructor(protected _httpService: Http) { }

    protected getHeader() {
        return new Headers({
            'Authorization':
                'Bearer '.concat(localStorage.getItem("token")),
            'Content-Type':
                'application/json'
        });
    }

    protected handleError(error: Response) {
        console.error(error);
        var message = error.json()["error_description"];
        if (!message) {
            message = "Error al establecerse una conexion con el servidor.";
        }
        alert(message);
        return Observable.throw(error);
    }
}