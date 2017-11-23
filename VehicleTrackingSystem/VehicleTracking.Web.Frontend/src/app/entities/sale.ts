export class Sale {

    buyerName: string;
    buyerPhoneNumber: string;
    sellingPrice: number;
    dateTime: Date;
    vehicleVIN: string;

    constructor(customerName: string = "", customerPhoneNumber: string = "",
        sellingPrice: number = 0) {
        this.buyerName = customerName;
        this.buyerPhoneNumber = customerPhoneNumber;
        this.sellingPrice = sellingPrice;
        this.dateTime = new Date();
    }
}