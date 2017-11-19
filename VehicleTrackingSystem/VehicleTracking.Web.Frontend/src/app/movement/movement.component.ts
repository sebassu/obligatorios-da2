import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Subzone } from '../entities/subzone';
import { SubzoneService } from '../services/subzone.service';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { MovementIn } from '../entities/movement-in';
import { MovementService } from '../services/movement.service';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styleUrls: ['./movement.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class MovementComponent implements OnInit {

  subzones: Array<Subzone>;
  vehicles: Array<Vehicle>

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
      .subscribe(vehiclesObtained => this.vehicles = vehiclesObtained);
    this.vehicles.map((itemInArray) => itemInArray.vin); 
  }

  private registerMovement(vehicleVIN: string, arrivalName: string): void {
    this._movementService.registerNewMovement(8);//aca va el id de la subzona de destino
                                                //acordarme que falta agregar en el URL el vin del vehiculo y 
                                                ///Movements para registrar el movimiento
  }

}
