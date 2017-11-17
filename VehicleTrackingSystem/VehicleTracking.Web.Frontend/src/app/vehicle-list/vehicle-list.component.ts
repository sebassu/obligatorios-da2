import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['../styles/list-styles.css', './vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  vehicles: Array<Vehicle>;

  constructor() {
    this.vehicles = [];
  }

  ngOnInit() {
  }

  private openVehicleHistoryFor(vehicleVin: string) {

  }

}