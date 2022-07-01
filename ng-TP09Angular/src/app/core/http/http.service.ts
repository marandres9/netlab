import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, of, throwError } from 'rxjs'
import { Region } from 'src/app/modules/region/model/Region'
import { RegionDetails } from 'src/app/modules/region/model/RegionDetails'
import { Shipper } from 'src/app/modules/shipper/models/Shipper'
import { ShipperDetails } from 'src/app/modules/shipper/models/ShipperDetails'
import { environment } from 'src/environments/environment'

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    constructor(private http: HttpClient) {}

    getAllShippers() {
        return this.http.get<Shipper[]>(environment.url + 'api/shippers/')
    }
    getDetailedShipper(id: number) {
        return this.http.get<ShipperDetails>(environment.url + `api/shippers/${id}`)
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

    getAllRegions() {
        return this.http.get<Region[]>(environment.url + 'api/regions/')
    }
    getDetailedRegion(id: number) {
        return this.http
            .get<RegionDetails>(environment.url + `api/regions/${id}`)
            .pipe(catchError(this.handleError))
    }
    postRegion(newRegion: Region) {
        return this.http
            .post<Region>(environment.url + 'api/regions/add', newRegion)
            .pipe(catchError(this.handleError))
    }
    putRegion(editedRegion: Region) {
        return this.http
            .put<Region>(environment.url + 'api/regions/edit', editedRegion)
            .pipe(catchError(this.handleError))
    }
    deleteRegion(id: number) {
        return this.http
            .delete<number>(environment.url + `api/regions/delete/${id}`)
            .pipe(catchError(this.handleError))
    }

    private handleError(error: HttpErrorResponse) {
        switch (error.status) {
            case 404:
                return throwError(() => new Error('The requested object was not found.'))
            default:
                return throwError(
                    () => new Error('Server denied request: ' + error.error.Message)
                )
        }
    }
}
