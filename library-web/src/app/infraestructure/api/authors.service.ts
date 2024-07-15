import { BaseResponse } from '../../domain/models/base';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { BookResponse } from '../../domain/models/book';
import { BooksGateway } from '../../domain/gateway/books.gateway';
import { AuthorsGateway } from '../../domain/gateway/authors.gateway';
import { Author, AuthorRequest } from '../../domain/models/author';

@Injectable({
    providedIn: 'root'
})
export class AuthorsApiService extends AuthorsGateway {
    private _url = 'https://localhost:7202/api/authors';

    constructor(private http: HttpClient) { super(); }

    override getAuthors(): Observable<BaseResponse<Author[]>> {
        return this.http.get<BaseResponse<Author[]>>(this._url)
    }

    override addAuthor(request: AuthorRequest): Observable<BaseResponse<any>> {
        return this.http.post<BaseResponse<any>>(this._url, request)
    }

    override deleteAuthor(id: string): Observable<BaseResponse<any>> {
        return this.http.delete<BaseResponse<any>>(this._url + '/' + id)
    }
}