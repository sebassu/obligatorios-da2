import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { environment } from '../../environments/environment';
import { Transport } from '../entities/transport';

import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { BaseService } from './baseService';

@Injectable()
export class TransportService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Transports";

    constructor(_httpService: Http) { super(_httpService); }

    getTransports(): Observable<Array<Transport>> {
        let header = this.getHeader();
        return this._httpService.get(TransportService.URL, { 'headers': header })
            .do((response: Response) => <Array<Transport>>response.json())
            .catch(this.handleError);
    }

    registerNewTransport(transportedLotsNames: Array<string>) {
        let header = this.getHeader();
        let body = { "StartDateTime": new Date(), "TransportedLotsNames": transportedLotsNames }
        return this._httpService.post(TransportService.URL, body, { 'headers': header })
            .do((response: Response) => alert("Transporte registrado correctamente."))
            .catch(this.handleError);
    }
}