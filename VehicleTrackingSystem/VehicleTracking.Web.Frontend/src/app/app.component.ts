import { Component } from '@angular/core';
import { LotService } from './services/lot.service';
import { TransportService } from './services/transport.service';
import { VehicleService } from './services/vehicle.service';
import { SubzoneService } from './services/subzone.service';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  providers: [LotService, TransportService, VehicleService, SubzoneService]
})
export class AppComponent {
  title = 'app';
}
