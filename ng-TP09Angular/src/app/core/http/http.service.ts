import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { environment } from 'src/environments/environment'
import { Shipper, ShipperDetails } from '../../shared/models/Shipper'

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    constructor(private http: HttpClient) {}

    getAllShippers() {
        return this.http.get<Shipper[]>(environment.url + 'api/shippers/')
    }

    getDetailsShippers(id: number) {
        return this.http.get<ShipperDetails>(environment.url + `api/shippers/${id}`)
    }

    postShipper(shipper: Shipper) {
        return this.http.post<Shipper>(environment.url + 'api/shippers/add', shipper)
    }
}
