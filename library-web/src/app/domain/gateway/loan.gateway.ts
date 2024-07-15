import { Observable } from "rxjs";
import { Loan, Reservation } from "../models/loan";
import { BaseResponse } from "../models/base";

export abstract class LoanGateway {
    abstract getMyReservations(): Observable<BaseResponse<Loan[]>>
    abstract returnBook(id: string): Observable<BaseResponse<any>>
    abstract reserve(bookId: string): Observable<BaseResponse<Reservation>> 
}