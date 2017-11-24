export class Damage {

    description: string;
    images: Array<string>;

    constructor(description: string = "",
        images: Array<string> = []) {
        this.description = description;
        this.images = images;
    }
}