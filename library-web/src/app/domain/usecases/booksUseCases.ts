import { BookRequest } from './../models/book';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseResponse } from "../models/base";
import { BookResponse } from "../models/book";
import { BooksGateway } from "../gateway/books.gateway";

@Injectable({
    providedIn: 'root'
})
export class BooksUsesCases {
    constructor(private _booksGateway: BooksGateway) { }
    getBooks(): Observable<BaseResponse<BookResponse[]>> {
        return this._booksGateway.getBooks()
    }

    addBook(request: BookRequest): Observable<BaseResponse<any>> {
        return this._booksGateway.addBook(request)
    }

    deleteBook(id: string): Observable<BaseResponse<any>> {
        return this._booksGateway.deleteBook(id)
    }
}