export class Sale {

    customerName: string;
    customerPhoneNumber: string;
    sellingPrice: number;
    dateTime: Date;
    vehicleVIN: string;

    constructor(customerName: string = "", customerPhoneNumber: string = "",
        sellingPrice: number = 0) {
        this.customerName = customerName;
        this.customerPhoneNumber = customerPhoneNumber;
        this.sellingPrice = sellingPrice;
        this.dateTime = new Date();
    }
}