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

    constructor(vin: string = "", type: string = "", brand: string = "",
        model: string = "", color: string = "", year: number = 0,
        currentStage: string = "") {
        this.vin = vin;
        this.brand = brand;
        this.model = model;
        this.color = color;
        this.year = year;
        this.currentStage = currentStage;
        this.type = type;
    }
}