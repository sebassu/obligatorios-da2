import { environment } from "../../environments/environment.prod";

export class Vehicle {

    vin: string;
    type: string;
    brand: string;
    model: string;
    color: string;
    year: number;
    currentStage: string;
    wasLotted: boolean;
    portInspectionId: string;
    hasYardInspection: boolean;

    constructor(vin: string, type: string, brand: string, model: string,
        color: string, year: number, currentStage: string) {
        this.vin = vin;
        this.brand = brand;
        this.model = model;
        this.color = color;
        this.year = year;
        this.currentStage = currentStage;
        this.setVehicleType(type);
    }

    private setVehicleType(typeToSet: string): void {
        if (typeToSet == environment.CAR_TYPE) {
            this.type = "Automóvil";
        } else if (typeToSet == environment.TRUCK_TYPE) {
            this.type = "Camión";
        } else if (typeToSet == environment.SUV_TYPE) {
            this.type = "SUV";
        } else if (typeToSet == environment.VAN_TYPE) {
            this.type = "Camioneta";
        } else if (typeToSet == environment.MINI_VAN_TYPE) {
            this.type = "Mini-van";
        } else {
            this.type = "Tipo desconocido";
        }
    }
}