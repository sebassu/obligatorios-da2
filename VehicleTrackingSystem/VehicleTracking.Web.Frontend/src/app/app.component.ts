import { Component } from '@angular/core';
import { LotService } from './services/lot.service';
import { TransportService } from './services/transport.service';
import { VehicleService } from './services/vehicle.service';
import { SubzoneService } from './services/subzone.service';
import { LocationService } from './services/location.service';
import { InspectionService } from './services/inspection.service';
import { MovementService } from './services/movement.service';
import { LoginService } from './services/login-service';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  providers: [LotService, TransportService, VehicleService, SubzoneService,
    LocationService, InspectionService, MovementService, LoginService]
})
export class AppComponent {
  title = 'app';
}
