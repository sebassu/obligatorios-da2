import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';

@Injectable()
export class LocationService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Locations";

    constructor(_httpService: Http) { super(_httpService); }

    getPorts(): Observable<Array<string>> {
        let url = LocationService.URL + "/Ports";
        let header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map((response: Response) => <Array<string>>response.json())
            .catch(this.handleError);
    }

    getYards(): Observable<Array<string>> {
        let url = LocationService.URL + "/Yards";
        let header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map((response: Response) => <Array<string>>response.json())
            .catch(this.handleError);
    }
}