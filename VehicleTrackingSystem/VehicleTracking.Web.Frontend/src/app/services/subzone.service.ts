import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { Subzone } from '../entities/subzone';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';

@Injectable()
export class SubzoneService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Subzones";

    constructor(_httpService: Http) { super(_httpService); }

       getSubzones(): Observable<Array<Subzone>> {
        let header = this.getHeader();
        return this._httpService.get(SubzoneService.URL, { 'headers': header })
            .map((response: Response) => <Array<Subzone>>response.json())
            .catch(this.handleError);
    }
}