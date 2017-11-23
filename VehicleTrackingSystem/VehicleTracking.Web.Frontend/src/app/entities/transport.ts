export class Transport {

    id: number;
    transporterUsername: string;
    startDateTime: string;
    transportedLotsNames: Array<string>;
    endDateTime: string;

    constructor(id: number = 0, transporterUsername: string = "", startDateTime: string = "",
        transportedLotsNames: Array<string> = []) {
        this.id = id;
        this.transporterUsername = transporterUsername;
        this.startDateTime = startDateTime;
        this.transportedLotsNames = transportedLotsNames;
    }
}