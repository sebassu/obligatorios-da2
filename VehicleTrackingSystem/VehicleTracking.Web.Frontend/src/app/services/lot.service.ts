import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';

import { Lot } from '../entities/lot';
import { environment } from '../../environments/environment';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { BaseService } from './base.service';

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

    registerNewLot(lotToAdd: Lot) {
        let header = this.getHeader();
        return this._httpService.post(LotService.URL, JSON.stringify(lotToAdd), { 'headers': header })
            .map((response: Response) => alert("Lote creado correctamente."))
            .subscribe(null, err => this.handleError(err));
    }

    deleteLotWithName(nameOfLotToDelete: string) {
        let url = LotService.URL + "/" + nameOfLotToDelete;
        let header = this.getHeader();
        return this._httpService.delete(url, { 'headers': header })
            .map((response: Response) => alert("Lote eliminado correctamente."))
            .subscribe(null, err => this.handleError(err));
    }

    getLotWithName(nameOfLotToFind: string): Observable<Lot> {
        let url = LotService.URL + "/" + nameOfLotToFind;
        let header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map((response: Response) => <Lot>response.json())
            .catch(this.handleError);
    }

    editLotWithName(nameOfLotTOEdit: string, lotData: Lot) {
        let url = LotService.URL + "/" + nameOfLotTOEdit;
        let header = this.getHeader();
        return this._httpService.put(url, JSON.stringify(lotData), { 'headers': header })
            .map((response: Response) => alert("Lote modificado correctamente."))
            .subscribe(null, err => this.handleError(err));
    }
}