import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Shipper, ShipperDetails } from 'src/app/modules/shipper/models/Shipper'
import { environment } from 'src/environments/environment'

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    constructor(private http: HttpClient) {}

    getAllShippers() {
        return this.http.get<Shipper[]>(environment.url + 'api/shippers/')
    }

    getDetailsShippers(id: number) {
        return this.http.get<ShipperDetails>(
            environment.url + `api/shippers/${id}`
        )
    }

    postShipper(shipper: Shipper) {
        return this.http.post<Shipper>(environment.url + 'api/shippers/add', shipper)
    }

    putShipper(edited: Shipper) {
        return this.http.put<Shipper>(environment.url + 'api/shippers/edit', edited)
    }

    deleteShipper(id: number) {
        return this.http.delete<number>(environment.url + `api/shippers/delete/${id}`)
    }
}
