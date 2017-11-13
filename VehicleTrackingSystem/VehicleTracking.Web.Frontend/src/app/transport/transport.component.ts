import { Component, OnInit } from '@angular/core';
import { LotService } from '../lot/lot.service';
import { Lot } from '../lot/lot';

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

  constructor(private _lotService: LotService) {
    this.transportedLotsNames = [];
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
    /*this.availableLots = [new Lot("Mario Santos", "El lotecito", "Buen Lote", ["AA", "BB"], true),
    new Lot("Emilio Ravenna", "Otro lote", "Buen Lote", ["AA", "BB"], true)];*/
  }

  beginTransport(): void {

  }

}
