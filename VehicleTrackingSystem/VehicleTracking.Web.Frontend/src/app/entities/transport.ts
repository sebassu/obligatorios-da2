export class Transport {

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
        this.type = type;
        this.brand = brand;
        this.model = model;
        this.color = color;
        this.year = year;
        this.currentStage = currentStage;
    }
}