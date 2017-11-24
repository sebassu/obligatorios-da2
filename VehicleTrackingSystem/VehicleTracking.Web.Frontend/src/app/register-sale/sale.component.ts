import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { VehicleService } from '../services/vehicle.service';
import { SaleService } from '../services/saleService';
import { environment } from '../../environments/environment';
import { Sale } from '../entities/sale';

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html',
  styleUrls: ['./sale.component.css']
})
export class SaleComponent implements OnInit {

  selectedVehicleVIN: string;
  buyerName: string;
  buyerPhoneNumber: string;
  sellingPrice: number;
  vehicles: Array<Vehicle>

  constructor(private _vehicleService: VehicleService,
    private _saleService: SaleService) {
    this.vehicles = [];
  }

  ngOnInit() {
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.initializeVehicles(vehiclesObtained));
  }

  private initializeVehicles(obtainedVehicles: Array<Vehicle>): void {
    for (let vehicle of obtainedVehicles) {
      if (vehicle.currentStage === environment.READY_FOR_SALE_STAGE) {
        this.vehicles.push(vehicle);
      }
    }
  }

  registerSale() {
    let saleToRegister = new Sale(this.buyerName,
      this.buyerPhoneNumber, this.sellingPrice);
    this._saleService.registerNewSale(this.selectedVehicleVIN, saleToRegister);
  }
}