import { Component, OnInit } from '@angular/core';
import { Transport } from '../entities/transport';
import { TransportService } from '../services/transport.service';

@Component({
  selector: 'app-transport-list',
  templateUrl: './transport-list.component.html',
  styleUrls: ['../styles/list-styles.css', './transport-list.component.css']
})
export class TransportListComponent implements OnInit {

  transports: Array<Transport>;
  selectedTransport: Transport;

  constructor(private _transportService: TransportService) {
    this.transports = [];
  }

  ngOnInit(): void {
    this._transportService.getTransports()
      .subscribe(transportsObtained => this.transports = transportsObtained);
  }

  private setSelectedTransportId(transport: Transport) {
    this.selectedTransport = transport;
  }

  private finalizeSelectedTransport() {
    this._transportService.finalizeTransportWithId(this.selectedTransport.id);
  }

  private prettyPrintDate(someDate: string): string {
    if (someDate == null) {
      return "N/a";
    } else {
      return new Date(someDate).toLocaleString();
    }
  }
}