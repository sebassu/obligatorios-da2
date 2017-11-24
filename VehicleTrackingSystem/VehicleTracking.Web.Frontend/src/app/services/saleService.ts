import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { Sale } from '../entities/sale';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';

@Injectable()
export class SaleService extends BaseService {

    constructor(_httpService: Http) { super(_httpService); }

    getSales(): Observable<Array<Sale>> {
        let url = environment.APIURL + "/api/Sales";
        let header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map((response: Response) => <Array<Sale>>response.json())
            .catch(this.handleError);
    }

    registerNewSale(vehicleVIN: string, saleToAdd: Sale) {
        let url = environment.APIURL + "/api/Vehicles/" + vehicleVIN + "/Sale";
        let header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(saleToAdd), { 'headers': header })
            .map((response: Response) => alert("Venta registrada correctamente."))
            .subscribe(null, err => this.handleError(err));
    }
}