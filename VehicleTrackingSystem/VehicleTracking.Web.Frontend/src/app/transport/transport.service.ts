import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response } from '@angular/http';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class TransportService {

    private static URL: string = environment.APIURL + "/api/Transport";

    constructor(private _httpService: Http) { }

    getTransports(): Observable<Array<Transport>> {
        return this._httpService.get(TransportService.URL)
            .map((response: Response) => <Array<Transport>>response.json())
            .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error);
    }
}