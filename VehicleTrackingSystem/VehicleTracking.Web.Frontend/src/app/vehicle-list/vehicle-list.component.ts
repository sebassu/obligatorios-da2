import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['../styles/list-styles.css']
})
export class VehicleListComponent implements OnInit {

  vehicles: Array<Vehicle>;

  constructor(private _vehicleService: VehicleService,
    private _router: Router) {
    this.vehicles = [];
  }

  ngOnInit(): void {
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.vehicles = vehiclesObtained);
  }

  private openVehicleHistoryFor(vehicleVin: string) {
    this._router.navigate(['/app/vehicleHistory', vehicleVin]);
  }
}