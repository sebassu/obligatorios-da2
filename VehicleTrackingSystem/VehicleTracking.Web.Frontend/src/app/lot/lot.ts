export class Lot {
    creatorUsername: string;
    name: string;
    description: string;
    vehicleVINs: Array<number>;
    isReadyForTransport: boolean;

    constructor(creatorUsername:string, name:string, description:string, 
    vehicleVINs:Array<number>){
        this.creatorUsername = creatorUsername;
        this.name = name;
        this.description = description;
        this.vehicleVINs = vehicleVINs;
    }
}