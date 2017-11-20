import { Damage } from "./damage";

export class Inspection {

    locationName: string;
    dateTime: Date;
    damages: Array<Damage>;

    constructor(locationName: string, dateTime: Date,
        damages: Array<Damage>) {
        this.locationName = locationName;
        this.dateTime = dateTime;
        this.damages = damages;
    }
}