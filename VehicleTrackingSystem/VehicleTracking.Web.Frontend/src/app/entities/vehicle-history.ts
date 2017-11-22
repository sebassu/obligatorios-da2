import { Lot } from "./lot";
import { Inspection } from "./inspection";
import { Movement } from "./movement-in";
import { Transport } from "./transport";
import { Sale } from "./sale";

export class VehicleHistory {

    lotData: Lot;
    portInspectionData: Inspection;
    transportData: Transport;
    yardInspectionData: Inspection;
    movementsData: Array<Movement>;
    saleData: Sale;

    constructor() { }
}