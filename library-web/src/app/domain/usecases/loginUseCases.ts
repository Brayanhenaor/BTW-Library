import { Injectable } from "@angular/core";
import { LoginRequest, LoginResponse, RegisterRequest } from "../models/login";
import { Observable } from "rxjs";
import { BaseResponse } from "../models/base";
import { AuthGateway } from "../gateway/login.gateway";

@Injectable({
    providedIn: 'root'
})
export class AuthUsesCases {
    constructor(private _loginGateway: AuthGateway) { }
    login(request: LoginRequest): Observable<BaseResponse<LoginResponse>> {
        return this._loginGateway.login(request)
    }

    register(request: RegisterRequest): Observable<BaseResponse<any>> {
        return this._loginGateway.register(request)
    }
}