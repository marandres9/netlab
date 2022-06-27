import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Shipper, ShipperDetails } from '../../shared/models/Shipper'

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    private url = 'https://localhost:44359'

    constructor(private http: HttpClient) {}

    getAllShippers() {
        return this.http.get<Shipper[]>(`${this.url}/api/shippers/`)
    }

    getDetailsShippers(id: number) {
        return this.http.get<ShipperDetails>(`${this.url}/api/shippers/${id}`)
    }

    postShipper(shipper: Shipper) {
        return this.http.post<Shipper>(`${this.url}/api/shippers/add`, shipper)
    }
}
