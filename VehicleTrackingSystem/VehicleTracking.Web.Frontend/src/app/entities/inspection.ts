import { Damage } from "./damage";

export class Inspection {

    responsiblesUsername: string;
    locationName: string;
    dateTime: string;
    damages: Array<Damage>;

    constructor(locationName: string = "", dateTime: string = "",
        damages: Array<Damage> = []) {
        this.locationName = locationName;
        this.dateTime = dateTime;
        this.damages = damages;
    }
}