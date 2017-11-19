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
        if (typeToSet == "0") {
            this.type = "Automóvil";
        } else if (typeToSet == "1") {
            this.type = "Camión";
        } else if (typeToSet == "2") {
            this.type = "SUV";
        } else if (typeToSet == "3") {
            this.type = "Camioneta";
        } else if (typeToSet == "4") {
            this.type = "Mini-van";
        } else {
            this.type = "Tipo desconocido";
        }
    }
}