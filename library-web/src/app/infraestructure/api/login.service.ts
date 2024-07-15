import { BaseResponse } from '../../domain/models/base';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginRequest, LoginResponse, RegisterRequest } from "../../domain/models/login";
import { HttpClient } from "@angular/common/http";
import { AuthGateway } from '../../domain/gateway/login.gateway';

@Injectable({
    providedIn: 'root'
})
export class AuthApiService extends AuthGateway {
    private _url = 'https://localhost:7202/api/auth/';

    constructor(private http: HttpClient) { super(); }

    login(request: LoginRequest): Observable<BaseResponse<LoginResponse>> {
        return this.http.post<BaseResponse<LoginResponse>>(this._url + 'login', request)
    }

    override register(request: RegisterRequest): Observable<BaseResponse<LoginResponse>> {
        return this.http.post<BaseResponse<any>>(this._url + 'register', request)
    }
}