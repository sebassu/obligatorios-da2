import { Component, OnInit } from '@angular/core';
import { LotService } from '../lot/lot.service';
import { Lot } from '../lot/lot';
import { TransportService } from './transport.service';

@Component({
  selector: 'transport-component',
  templateUrl: './transport.component.html',
  styleUrls: ['./transport.component.css']
})
export class TransportComponent implements OnInit {
  id: number;
  transporterUsername: string;
  startDateTime: Date;
  transportedLotsNames: Array<string>;
  endDateTime: Date;
  availableLots: Array<Lot>;
  errorMessage: string;

  constructor(private _lotService: LotService,
    private _transportService: TransportService) {
    this.transportedLotsNames = [];
    this.availableLots = [];
  }

  private addOrRemoveLot(lotName: string) {
    var index = this.transportedLotsNames.indexOf(lotName, 0);
    if (index > -1) {
      this.transportedLotsNames.splice(index, 1);
    } else {
      this.transportedLotsNames.push(lotName);
    }
  }

  ngOnInit(): void {
    this._lotService.getLots()
      .subscribe(lotsObtained => this.availableLots = lotsObtained);
  }

  private beginTransport(): void {

  }
}
