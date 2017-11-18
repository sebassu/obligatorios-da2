import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicleService';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['../styles/list-styles.css', './vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  vehicles: Array<Vehicle>;

  constructor(private _vehicleService: VehicleService) {
  }

  ngOnInit(): void {
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.vehicles =
        this.getDataToPrint(vehiclesObtained));
  }

  private getDataToPrint(vehiclesObtained: Array<Vehicle>): Array<Vehicle> {
    for (let vehicle of vehiclesObtained) {
      this.processVehicleTypes(vehicle);
      this.processStages(vehicle);
    }
    return vehiclesObtained;
  }

  private processVehicleTypes(vehicle: Vehicle): void {
    let type: string = vehicle.type;
    if (type == "0") {
      vehicle.type = "Automóvil";
    } else if (type == "1") {
      vehicle.type = "Camión";
    } else if (type == "2") {
      vehicle.type = "SUV";
    } else if (type == "3") {
      vehicle.type = "Camioneta";
    } else if (type == "4") {
      vehicle.type = "Mini-van";
    } else {
      vehicle.type = "Tipo desconocido";
    }
  }

  private processStages(vehicle: Vehicle): void {
    let stage: string = vehicle.currentStage;
    if (stage == "STUCK_IN_PROCESS") {
      vehicle.currentStage = "Trancado en el proceso";
    } else if (stage == "PORT") {
      vehicle.currentStage = "Puerto";
    } else if (stage == "TRANSPORT") {
      vehicle.currentStage = "Transporte";
    } else if (stage == "YARD") {
      vehicle.currentStage = "Patio";
    } else if (stage == "READY_FOR_SALE") {
      vehicle.currentStage = "Pronto para venta";
    } else if (stage == "SOLD") {
      vehicle.currentStage = "Vendido";
    } else {
      vehicle.currentStage = "Etapa desconocida";
    }
  }

  private openVehicleHistoryFor(vehicleVin: string) {
    alert(vehicleVin);
  }
}