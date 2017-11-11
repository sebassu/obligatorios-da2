import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response } from '@angular/http';

import { TransportComponent } from './transport.component';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class TransportServices {
    
    private WEB_API_URL : string = 'api/transports/test-api.json';

    constructor(private _httpService: Http) {  }

    getTransports(): Observable<Array<Transport>> {
        return this._httpService.get(this.WEB_API_URL)
        .map((response : Response) => <Array<Transport>> response.json())
        .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error|| 'Server error');
    }

}