import { Damage } from "./damage";

export class Inspection {

    responsiblesUsername: string;
    locationName: string;
    dateTime: Date;
    damages: Array<Damage>;

    constructor(locationName: string = "", dateTime: Date = new Date(),
        damages: Array<Damage> = []) {
        this.locationName = locationName;
        this.dateTime = dateTime;
        this.damages = damages;
    }
}