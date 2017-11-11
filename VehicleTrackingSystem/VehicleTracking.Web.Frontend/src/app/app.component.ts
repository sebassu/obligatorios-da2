import { Component } from '@angular/core';
import  { LotService } from './lot/lot.service';
import  { TransportService } from './transport/transport.service';

@Component({
  selector: 'app-root',
  template: `<transport-component></transport-component>`,
  providers: [LotService, TransportService]
})
export class AppComponent {
  title = 'app';
}
