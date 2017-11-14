import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { BaseService } from '../baseService';

@Injectable()
export class TransportService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Transports";

    constructor(_httpService: Http) { super(_httpService); }

    getTransports(): Observable<Array<Transport>> {
        let header = this.getHeader();
        return this._httpService.get(TransportService.URL, { 'headers': header })
            .map((response: Response) => <Array<Transport>>response.json())
            .catch(this.handleError);
    }

    registerNewTransport(transportedLotsNames: Array<string>) {
        let header = this.getHeader();
        return this._httpService.post(TransportService.URL, transportedLotsNames, { 'headers': header })
            .map((response: Response) => alert("Transporte registrado correctamente."))
            .catch(this.handleError);
    }
}