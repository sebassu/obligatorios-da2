import { Component, OnInit } from '@angular/core';
import { LotService } from '../services/lot.service';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { Lot } from '../entities/lot';
import { environment } from '../../environments/environment';

@Component({
  selector: 'lot-component',
  templateUrl: './lot.component.html',
  styleUrls: ['../styles/list-styles.css', './lot.component.css']
})
export class LotComponent implements OnInit {
  name: string;
  description: string;
  vehicleVINs: Array<string>;
  availableVehicles: Array<Vehicle>;

  constructor(private _vehicleService: VehicleService,
    private _lotService: LotService) {
    this.vehicleVINs = [];
    this.availableVehicles = [];
  }

  private addOrRemoveVIN(someVIN: string) {
    var index = this.vehicleVINs.indexOf(someVIN, 0);
    if (index > -1) {
      this.vehicleVINs.splice(index, 1);
    } else {
      this.vehicleVINs.push(someVIN);
    }
  }

  ngOnInit(): void {
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.initializeVehicles(vehiclesObtained));
  }

  private initializeVehicles(obtainedVehicles: Array<Vehicle>): void {
    for (let vehicle of obtainedVehicles) {
      if (vehicle.currentStage === environment.PORT_STAGE &&
        !vehicle.wasLotted) {
        this.availableVehicles.push(vehicle);
      }
    }
  }

  private registerNewLot(): void {
    if (this.vehicleVINs.length > 0) {
      let lotToAdd = new Lot(this.name, this.description, this.vehicleVINs);
      this._lotService.registerNewLot(lotToAdd);
    } else {
      alert("Es necesario seleccionar al menos un vehículo para el lote.");
    }
  }
}