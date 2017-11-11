import { Component } from '@angular/core';

@Component({
  selector: 'transport-component',
  template: '<h1>Hello {{transporterUsername}}</h1>',
  templateUrl: './transport.component.html',
  styleUrls: ['./transport.component.css']
})
export class TransportComponent {

  id: number;
  transporterUsername: string = "UnUsuario";
  startDateTime: Date;
  transportedLotsNames: string[];
  endDateTime: Date

  constructor(id:number, transporterUsername: string, startDateTime: Date,
    transportedLotsNames: string[], endDateTime: Date) {
    this.id = id;
    this.transporterUsername = transporterUsername;
    this.startDateTime = startDateTime;
    this.transportedLotsNames = transportedLotsNames;
    this.endDateTime = endDateTime;
  }
}
