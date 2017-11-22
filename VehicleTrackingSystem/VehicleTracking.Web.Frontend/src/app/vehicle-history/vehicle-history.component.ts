import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Lot } from "../entities/lot";
import { Inspection } from "../entities/inspection";
import { Movement } from "../entities/movement";
import { Sale } from "../entities/sale";
import { VehicleService } from '../services/vehicle.service';
import { VehicleHistory } from '../entities/vehicle-history';
import { Transport } from '../entities/transport';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-vehicle-history',
  templateUrl: './vehicle-history.component.html',
  styleUrls: ['../styles/list-styles.css', './vehicle-history.component.css']
})
export class VehicleHistoryComponent implements OnInit {

  vehicleVIN: string;

  hasNoLotData: boolean;
  hasNoPortInspectionData: boolean;
  hasNoTransportData: boolean;
  hasNoYardInspectionData: boolean;
  hasNoMovementsData: boolean;
  hasNoSaleData: boolean;

  lotData: Lot;
  portInspectionData: Inspection;
  transportData: Transport;
  yardInspectionData: Inspection;
  movementsData: Array<Movement>;
  saleData: Sale;

  constructor(private _currentRoute: ActivatedRoute,
    private _vehicleService: VehicleService) {
    this.vehicleVIN = this._currentRoute.snapshot.params['vehicleVIN'];
    this.lotData = new Lot();
    this.portInspectionData = new Inspection();
    this.transportData = new Transport();
    this.yardInspectionData = new Inspection();
    this.movementsData = [];
    this.saleData = new Sale();
  }

  ngOnInit() {
    this._vehicleService.getHistoryOfVehicleWithVIN(this.vehicleVIN)
      .subscribe(obtainedHistory => this.initializeAttributes(obtainedHistory));
  }

  // Even when hiding HTML components, angular failed on null attributes.
  private initializeAttributes(obtainedHistory: VehicleHistory) {
    if (obtainedHistory.lotData == null) {
      this.lotData = new Lot();
      this.hasNoLotData = true;
    } else {
      this.lotData = obtainedHistory.lotData;
      this.hasNoLotData = false;
    }

    if (obtainedHistory.portInspectionData == null) {
      this.portInspectionData = new Inspection();
      this.hasNoPortInspectionData = true;
    } else {
      this.portInspectionData = obtainedHistory.portInspectionData;
      this.hasNoPortInspectionData = false;
    }

    if (obtainedHistory.transportData == null) {
      this.transportData = new Transport();
      this.hasNoTransportData = true;
    } else {
      this.transportData = obtainedHistory.transportData;
      this.hasNoTransportData = false;
    }

    if (obtainedHistory.yardInspectionData == null) {
      this.yardInspectionData = new Inspection();
      this.hasNoYardInspectionData = true;
    } else {
      this.yardInspectionData = obtainedHistory.yardInspectionData;
      this.hasNoYardInspectionData = false;
    }

    this.movementsData = obtainedHistory.movementsData;
    this.hasNoMovementsData = obtainedHistory.movementsData.length == 0;

    if (obtainedHistory.saleData == null) {
      this.saleData = new Sale();
      this.hasNoSaleData = true;
    } else {
      this.saleData = obtainedHistory.saleData;
      this.hasNoSaleData = false;
    }
  }
}