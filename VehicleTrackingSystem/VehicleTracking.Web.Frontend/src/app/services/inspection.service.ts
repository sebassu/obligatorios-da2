import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';
import { Inspection } from '../entities/inspection';

@Injectable()
export class InspectionService extends BaseService {

    private static URL: string = environment.APIURL + "/api/Vehicles/";

    constructor(_httpService: Http) { super(_httpService); }

    registerPortInspection(vehicleVIN: string, inspectionToAdd: Inspection) {
        let url = InspectionService.URL + vehicleVIN + "/PortInspection";
        let header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(inspectionToAdd), { 'headers': header })
            .map((response: Response) => alert("Inspección de puerto registrada correctamente."))
            .subscribe(null, err => this.handleError(err));
    }

    registerYardInspection(vehicleVIN: string, inspectionToAdd: Inspection) {
        let url = InspectionService.URL + vehicleVIN + "/YardInspection";
        let header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(inspectionToAdd), { 'headers': header })
            .map((response: Response) => alert("Inspección de patio registrada correctamente."))
            .subscribe(null, err => this.handleError(err));
    }
}