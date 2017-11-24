import { Component, OnInit } from '@angular/core';
import { LotService } from '../services/lot.service';
import { Lot } from '../entities/lot';
import { TransportService } from '../services/transport.service';

@Component({
  selector: 'transport-component',
  templateUrl: './transport.component.html',
  styleUrls: ['../styles/list-styles.css', './transport.component.css']
})
export class TransportComponent implements OnInit {
  transportedLotsNames: Array<string>;
  availableLots: Array<Lot>;

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
      .subscribe(lotsObtained => this.initializeLots(lotsObtained));
  }

  private initializeLots(lotsObtained: Array<Lot>): void {
    for (let lot of lotsObtained) {
      if (lot.isReadyForTransport) {
        this.availableLots.push(lot);
      }
    }
  }

  private beginTransport(): void {
    this._transportService.registerNewTransport(this.transportedLotsNames);
  }
}