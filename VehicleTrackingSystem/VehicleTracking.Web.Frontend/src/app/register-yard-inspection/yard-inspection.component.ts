import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { LocationService } from '../services/location.service';
import { Vehicle } from '../entities/vehicle';
import { Damage } from '../entities/damage';
import { NgForm } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { Inspection } from '../entities/inspection';
import { InspectionService } from '../services/inspection.service';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-yard-inspection',
  templateUrl: './yard-inspection.component.html',
  styleUrls: ['../styles/list-styles.css', './yard-inspection.component.css'],
})
export class YardInspectionComponent implements OnInit {

  selectedVehicle: Vehicle;
  selectedLocation: string;
  vehicles: Array<Vehicle>;
  yardNames: Array<string>;
  damages: Array<Damage>;
  imageFiles: FileList;
  damageDescription: string;

  constructor(private _DomSanitizer: DomSanitizer, private _inspectionService: InspectionService,
    private _vehicleService: VehicleService, private _locationService: LocationService) {
    this.vehicles = [];
    this.yardNames = [];
    this.damages = [];
  }

  private getFiles(event) {
    this.imageFiles = event.target.files;
  }

  private attemptToAddDamage() {
    if (this.imageFiles.length > 0) {
      let images = this.getImageStrings();
      this.damages.push(new Damage(this.damageDescription, images));
      alert("Daño agregado exitosamente.");
    } else {
      alert("Error: es necesario ayardar evidencia fotográfica para"
        + " poder registrar un daño.");
    }
  }

  private updateInspectionDamages() {
    let inspectionIdToFind = this.selectedVehicle.portInspectionId;
    this._inspectionService.getInspectionWithId(inspectionIdToFind)
      .subscribe(foundInspection => this.damages = foundInspection.damages);
  }

  private getImageStrings(): Array<string> {
    let stringifiedImages: Array<string> = [];
    for (var i = 0; i < this.imageFiles.length; i++) {
      let file = this.imageFiles[i];
      if (!file.type.match('image.*')) {
        throw "Sólo se aceptan imágenes para este campo.";
      }
      this.getImageData(file, stringifiedImages);
    }
    return stringifiedImages;
  }

  private getImageData(file: File, stringifiedImages: Array<string>)
    : void {
    var reader = new FileReader();
    reader.onload = function (e) {
      stringifiedImages.push(reader.result);
    }
    reader.readAsDataURL(file);
  }

  ngOnInit() {
    this._vehicleService.getVehicles()
      .subscribe(obtainedVehicles => this.initializeVehicles(obtainedVehicles));
    this._locationService.getYards()
      .subscribe(yardsObtained => this.yardNames = yardsObtained);
  }

  private initializeVehicles(obtainedVehicles: Array<Vehicle>): void {
    for (let vehicle of obtainedVehicles) {
      if (vehicle.currentStage.indexOf(environment.YARD_STAGE_PREFIX) !== -1
        && !vehicle.hasYardInspection) {
        this.vehicles.push(vehicle);
      }
    }
  }

  private clearDamages() {
    this.damages = [];
  }

  private registerYardInspection() {
    let inspectionToRegister = new Inspection(this.selectedLocation,
      new Date(), this.damages);
    this._inspectionService.registerYardInspection(this.selectedVehicle.vin,
      inspectionToRegister);
  }
}