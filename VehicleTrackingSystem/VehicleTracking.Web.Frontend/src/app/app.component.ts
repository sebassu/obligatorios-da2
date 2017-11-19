import { Component } from '@angular/core';
import { LotService } from './services/lot.service';
import { TransportService } from './services/transport.service';
import { VehicleService } from './services/vehicle.service';
import { LocationService } from './services/location.service';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  providers: [LotService, TransportService,
    VehicleService, LocationService]
})
export class AppComponent {
  title = 'app';
}
