import { Component } from '@angular/core';
import { LotService } from './services/lot.service';
import { TransportService } from './services/transport.service';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  providers: [LotService, TransportService]
})
export class AppComponent {
  title = 'app';
}
