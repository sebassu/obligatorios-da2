import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { BaseService } from './baseService';

@Injectable()
export class VehicleService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Vehicles";

    constructor(_httpService: Http) { super(_httpService); }

    getTransports(): Observable<Array<Transport>> {
        let header = this.getHeader();
        return this._httpService.get(VehicleService.URL, { 'headers': header })
            .do((response: Response) => <Array<Transport>>response.json())
            .catch(this.handleError);
    }
}