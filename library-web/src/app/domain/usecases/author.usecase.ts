import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseResponse } from "../models/base";
import { AuthorsGateway } from "../gateway/authors.gateway";
import { Author, AuthorRequest } from "../models/author";

@Injectable({
    providedIn: 'root'
})
export class AuthorUsesCases {
    constructor(private _authorsGateway: AuthorsGateway) { }
    getAuthors(): Observable<BaseResponse<Author[]>> {
        return this._authorsGateway.getAuthors()
    }

    addAuthor(request: AuthorRequest): Observable<BaseResponse<any>> {
        return this._authorsGateway.addAuthor(request)
    }

    deleteAuthor(id: string): Observable<BaseResponse<any>> {
        return this._authorsGateway.deleteAuthor(id)
    }
}