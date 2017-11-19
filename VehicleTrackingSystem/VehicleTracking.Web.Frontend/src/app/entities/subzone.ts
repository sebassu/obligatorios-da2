export class Subzone {
    
        containerName: string;
        name: string;
        capacity: number;
        vehicleVINs: Array<string>
    
        constructor(containerName: string, name: string, capacity: number,
        vehicleVINs: Array<string>) {
            this.containerName = containerName;
            this.name = name;
            this.capacity = capacity;
            this.vehicleVINs = vehicleVINs;
        }
    }