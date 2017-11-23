import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { Router } from '@angular/router';
import { environment } from "../../environments/environment.prod";

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

  private prettyPrintType(type: string) {
    if (type == environment.CAR_TYPE) {
      return "Automóvil";
    } else if (type == environment.TRUCK_TYPE) {
      return "Camión";
    } else if (type == environment.SUV_TYPE) {
      return "SUV";
    } else if (type == environment.VAN_TYPE) {
      return "Camioneta";
    } else if (type == environment.MINI_VAN_TYPE) {
      return "Mini-van";
    } else {
      return "Tipo desconocido";
    }
  }
}