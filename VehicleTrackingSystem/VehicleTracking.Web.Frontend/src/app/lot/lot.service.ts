import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response } from '@angular/http';

import { LotComponent } from './lot.component';
import { Lot } from './lot';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class LotService {
     
    private static URL: string = environment.APIURL + "api/Lots";

    constructor(private _httpService: Http) {  }

    getLots(): Observable<Array<Lot>> {
        return this._httpService.get(LotService.URL)
        .map((response : Response) => <Array<Lot>> response.json())
        .catch(this.handleError);
    }

    private handleError(error: Response) {
        //console.error(error);
        alert(error);
        alert(error.json().error);
        return Observable.throw(error.json().error || 'Server error');
    }

}