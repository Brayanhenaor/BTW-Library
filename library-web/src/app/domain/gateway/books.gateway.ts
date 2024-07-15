import { Observable } from "rxjs";
import { BookRequest, BookResponse } from "../models/book";
import { BaseResponse } from "../models/base";

export abstract class BooksGateway {
    abstract deleteBook(id: string): Observable<BaseResponse<any>> 
    abstract addBook(request: BookRequest): Observable<BaseResponse<any>> 
    abstract getBooks(): Observable<BaseResponse<BookResponse[]>>
}