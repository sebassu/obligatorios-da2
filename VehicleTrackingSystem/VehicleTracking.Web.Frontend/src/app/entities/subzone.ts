export class Subzone {

    id: number
    containerName: string;
    name: string;
    capacity: number;
    vehicleVINs: Array<string>

    constructor(id: number = 0, containerName: string = "",
        name: string = "", capacity: number = 0,
        vehicleVINs: Array<string> = []) {
        this.containerName = containerName;
        this.name = name;
        this.capacity = capacity;
        this.vehicleVINs = vehicleVINs;
    }
}