import { Observable } from "rxjs";
import { BookResponse } from "../models/book";
import { BaseResponse } from "../models/base";
import { Author, AuthorRequest } from "../models/author";

export abstract class AuthorsGateway {
    abstract deleteAuthor(id: string): Observable<BaseResponse<any>>
    abstract addAuthor(request: AuthorRequest): Observable<BaseResponse<any>>
    abstract getAuthors(): Observable<BaseResponse<Author[]>>
}