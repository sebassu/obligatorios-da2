import { Component, OnInit } from '@angular/core';
import { Transport } from '../entities/transport';
import { TransportService } from '../services/transport.service';

@Component({
  selector: 'app-transport-list',
  templateUrl: './transport-list.component.html'
})
export class TransportListComponent implements OnInit {

  transports: Array<Transport>;
  selectedTransportId: number;

  constructor(private _transportService: TransportService) {
    this.transports = [];
  }

  ngOnInit(): void {
    this._transportService.getTransports()
      .subscribe(transportsObtained => this.transports = transportsObtained);
  }

  private finalizeTransport(transportId: number) {
    alert(transportId);
    this._transportService.finalizeTransportWithId(transportId);
  }
}