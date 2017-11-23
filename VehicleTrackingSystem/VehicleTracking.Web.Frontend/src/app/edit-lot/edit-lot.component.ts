import { Component, OnInit } from '@angular/core';
import { LotService } from '../services/lot.service';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { Lot } from '../entities/lot';
import { environment } from '../../environments/environment';

@Component({
  selector: 'edit-lot-component',
  templateUrl: './edit-lot.component.html',
  styleUrls: ['../styles/list-styles.css', './edit-lot.component.css']
})
export class EditLotComponent implements OnInit {

  editedLotName: string;
  foundLot: boolean;
  name: string;
  description: string;
  vehicleVINs: Array<string>;
  availableVehicles: Array<Vehicle>;
  previousVehicles: Array<string>;

  constructor(private _currentRoute: ActivatedRoute,
    private _vehicleService: VehicleService,
    private _lotService: LotService) {
    this.foundLot = false;
    this.editedLotName = this._currentRoute.snapshot.params['lotName'];
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
    this._lotService.getLotWithName(this.editedLotName)
      .subscribe(obtainedLot => this.setPreviousData(obtainedLot));
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.initializeVehicles(vehiclesObtained));
  }

  private setPreviousData(editedLot: Lot) {
    this.foundLot = true;
    this.name = editedLot.name;
    this.description = editedLot.description;
    this.previousVehicles = editedLot.vehicleVINs;
  }

  private initializeVehicles(obtainedVehicles: Array<Vehicle>): void {
    for (let vehicle of obtainedVehicles) {
      if (vehicle.currentStage === environment.PORT_STAGE &&
        !vehicle.wasLotted) {
        this.availableVehicles.push(vehicle);
      }
    }
  }

  private editLot(): void {
    if (this.vehicleVINs.length > 0) {
      let lotData = new Lot(this.name, this.description, this.vehicleVINs);
      this._lotService.editLotWithName(this.editedLotName, lotData);
    } else {
      alert("Es necesario seleccionar al menos un vehículo para el lote.");
    }
  }
}