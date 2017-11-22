export class Transport {

    id: number;
    transporterUsername: string;
    startDateTime: string;
    transportedLotsNames: Array<string>;
    endDateTime: string;

    constructor(id: number = 0, transporterUsername: string = "", startDateTime: Date = new Date(),
        transportedLotsNames: Array<string> = [], endDateTime: string = "") {
        this.id = id;
        this.transporterUsername = transporterUsername;
        this.startDateTime = startDateTime.toLocaleString();
        this.transportedLotsNames = transportedLotsNames;
        this.processStartDateTime(startDateTime);
    }

    private processStartDateTime(endDateTime: Date) {
        if (endDateTime === null) {
            this.endDateTime = "N/A";
        } else {
            this.endDateTime = endDateTime.toLocaleString();
        }
    }
}