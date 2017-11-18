export class Lot {

    creatorUsername: string;
    name: string;
    description: string;
    vehicleVINs: Array<string>;
    isReadyForTransport: boolean;

    constructor(creatorUsername: string, name: string, description: string,
        vehicleVINs: Array<string>, isReadyForTransport: boolean) {
        this.creatorUsername = creatorUsername;
        this.name = name;
        this.description = description;
        this.vehicleVINs = vehicleVINs;
        this.isReadyForTransport = isReadyForTransport;
    }
}