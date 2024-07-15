import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseResponse } from "../models/base";
import { BookResponse } from "../models/book";
import { Loan, Reservation } from "../models/loan";
import { LoanGateway } from "../gateway/loan.gateway";

@Injectable({
    providedIn: 'root'
})
export class LoanUsesCases {
    constructor(private _loanGateway: LoanGateway) { }
    getMyReservations(): Observable<BaseResponse<Loan[]>> {
        return this._loanGateway.getMyReservations()
    }
    returnBook(id: string): Observable<BaseResponse<any>> {
        return this._loanGateway.returnBook(id)
    }
    reserve(bookId: string): Observable<BaseResponse<Reservation>> {
        return this._loanGateway.reserve(bookId)
    }
}