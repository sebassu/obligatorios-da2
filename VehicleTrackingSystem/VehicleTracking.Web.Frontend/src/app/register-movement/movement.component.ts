import { Component, OnInit } from '@angular/core';
import { Subzone } from '../entities/subzone';
import { SubzoneService } from '../services/subzone.service';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { MovementService } from '../services/movement.service';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styleUrls: ['./movement.component.css']
})
export class MovementComponent implements OnInit {

  selectedVehicleVIN: string;
  arrivalId: string;
  subzones: Array<Subzone>;
  vehicles: Array<Vehicle>;

  constructor(private _subzoneService: SubzoneService, private _vehicleService: VehicleService,
    private _movementService: MovementService) {
    this.subzones = [];
    this.vehicles = [];
  }

  ngOnInit(): void {
    this._subzoneService.getSubzones()
      .subscribe(subzonesObtained => this.subzones = subzonesObtained);
    this.subzones.map((itemInArray) => itemInArray.name);
    this._vehicleService.getVehicles()
      .subscribe(obtainedVehicles => this.initializeVehicles(obtainedVehicles));
    this.vehicles.map((itemInArray) => itemInArray.vin);
  }

  private initializeVehicles(obtainedVehicles: Array<Vehicle>): void {
    for (let vehicle of obtainedVehicles) {
      if (vehicle.currentStage.indexOf(environment.YARD_STAGE_PREFIX)
        !== -1) {
        this.vehicles.push(vehicle);
      }
    }
  }

  private registerMovement(): void {
    this._movementService.registerNewMovement(this.arrivalId,
      this.selectedVehicleVIN);
  }
}