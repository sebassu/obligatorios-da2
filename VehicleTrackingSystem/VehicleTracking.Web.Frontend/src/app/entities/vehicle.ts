export class Vehicle {

    vin: string;
    type: string;
    brand: string;
    model: string;
    color: string;
    year: number;
    currentStage: string;

    constructor(vin: string, type: string, brand: string, model: string,
        color: string, year: number, currentStage: string) {
        this.vin = vin;
        this.brand = brand;
        this.model = model;
        this.color = color;
        this.year = year;
        this.setVehicleType(type);
        this.setProcessStage(currentStage);
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

    private setProcessStage(stageToSet: string): void {
        if (stageToSet == "STUCK_IN_PROCESS") {
            this.currentStage = "Trancado en el proceso";
        } else if (stageToSet == "PORT") {
            this.currentStage = "Puerto";
        } else if (stageToSet == "TRANSPORT") {
            this.currentStage = "Transporte";
        } else if (stageToSet == "YARD") {
            this.currentStage = "Patio";
        } else if (stageToSet == "READY_FOR_SALE") {
            this.currentStage = "Pronto para venta";
        } else if (stageToSet == "SOLD") {
            this.currentStage = "Vendido";
        } else {
            this.currentStage = "Etapa desconocida";
        }
    }
}