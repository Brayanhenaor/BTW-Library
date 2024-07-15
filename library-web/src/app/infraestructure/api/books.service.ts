import { BaseResponse } from '../../domain/models/base';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { BookRequest, BookResponse } from '../../domain/models/book';
import { BooksGateway } from '../../domain/gateway/books.gateway';

@Injectable({
    providedIn: 'root'
})
export class BooksApiService extends BooksGateway {
    private _url = 'https://localhost:7202/api/books/';

    constructor(private http: HttpClient) { super(); }

    override getBooks(): Observable<BaseResponse<BookResponse[]>> {
        return this.http.get<BaseResponse<BookResponse[]>>(this._url)
    }

    override addBook(request: BookRequest): Observable<BaseResponse<any>> {
        return this.http.post<BaseResponse<any>>(this._url, request)
    }

    override deleteBook(id: string): Observable<BaseResponse<any>> {
        return this.http.delete<BaseResponse<any>>(this._url + id)
    }
}