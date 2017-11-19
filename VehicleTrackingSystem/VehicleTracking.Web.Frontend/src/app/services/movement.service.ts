import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { environment } from '../../environments/environment';
import { MovementIn } from '../entities/movement-in';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';

@Injectable()
export class MovementService extends BaseService {

    private  static URL: string = environment.APIURL + "/api/Vehicles/";

    constructor(_httpService: Http) { super(_httpService); }

    registerNewMovement(arrival: number, VehicleVin: string) {
        let url = MovementService.URL +  + VehicleVin + "/Movement";
        let header = this.getHeader();
        let body = { "DateTime": new Date(), "ArrivalSubzoneId": arrival }
        return this._httpService.post(url, body, { 'headers': header })
            .map((response: Response) => alert("Movimiento registrado correctamente."))
            .catch(this.handleError);
    }
}