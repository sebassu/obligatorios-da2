import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { LotComponent } from './lot.component';
import { Lot } from './lot';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class LotService {

    private static URL: string = environment.APIURL + "/api/Lots";

    constructor(private _httpService: Http) { }

    getLots(): Observable<Array<Lot>> {
        alert(localStorage.getItem("token"));
        alert(localStorage.getItem("loggedUserRole"));
        let header = new Headers({
            'Authorization':
                'Bearer '.concat(localStorage.getItem("token")),
            'Content-Type':
                'application/json'
        });
        return this._httpService.get(LotService.URL, { 'headers': header })
            .map((response: Response) => <Array<Lot>>response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        alert(error);
        return Observable.throw(error);
    }
}