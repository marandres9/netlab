export class Shipper {
    private shipperID: number = 0
    private companyName: string = ''
    // private phone: string = ''

    public get ShipperID() {
        return this.shipperID
    }
    public get CompanyName() {
        return this.companyName
    }
    // public get Phone() {
    //     return this.phone
    // }

    public set ShipperID(shipperID: number) {
        this.shipperID = shipperID
    }
    public set CompanyName(companyName: string) {
        this.companyName = companyName
    }
    // public set Phone(phone: string) {
    //     this.phone = phone
    // }
}
