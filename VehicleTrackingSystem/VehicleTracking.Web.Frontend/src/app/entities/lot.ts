export class Lot {

    creatorUsername: string;
    name: string;
    description: string;
    vehicleVINs: Array<string>;
    isReadyForTransport: boolean;

    constructor(name: string = "", description: string = "",
        vehicleVINs: Array<string> = []) {
        this.name = name;
        this.description = description;
        this.vehicleVINs = vehicleVINs;
    }
}