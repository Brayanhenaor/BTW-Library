import { BaseResponse } from '../../domain/models/base';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Loan, Reservation } from '../../domain/models/loan';
import { LoanGateway } from '../../domain/gateway/loan.gateway';

@Injectable({
    providedIn: 'root'
})
export class LoanApiService extends LoanGateway {
    private _url = 'https://localhost:7202/api/loans';

    constructor(private http: HttpClient) { super(); }

    getMyReservations(): Observable<BaseResponse<Loan[]>> {
        return this.http.get<BaseResponse<Loan[]>>(this._url + "/my-reservations")
    }

    override returnBook(id: string): Observable<BaseResponse<any>> {
        return this.http.delete<BaseResponse<any>>(this._url + "/cancel/" + id)
    }

    override reserve(bookId: string): Observable<BaseResponse<Reservation>> {
        return this.http.post<BaseResponse<any>>(this._url + "/reserve/" + bookId, null)
    }
}