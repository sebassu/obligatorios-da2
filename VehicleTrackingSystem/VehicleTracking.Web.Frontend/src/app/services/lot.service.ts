import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { Lot } from '../entities/lot';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './baseService';

@Injectable()
export class LotService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Lots";

    constructor(_httpService: Http) { super(_httpService); }

    getLots(): Observable<Array<Lot>> {
        let header = this.getHeader();
        return this._httpService.get(LotService.URL, { 'headers': header })
            .map((response: Response) => <Array<Lot>>response.json())
            .catch(this.handleError);
    }
}