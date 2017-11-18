import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './baseService';
import { Vehicle } from '../entities/vehicle';

@Injectable()
export class VehicleService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Vehicles";

    constructor(_httpService: Http) { super(_httpService); }

    getVehicles(): Observable<Array<Vehicle>> {
        let header = this.getHeader();
        return this._httpService.get(VehicleService.URL, { 'headers': header })
            .map((response: Response) => <Array<Vehicle>>response.json())
            .catch(this.handleError);
    }
}