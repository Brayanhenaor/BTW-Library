import { Observable } from "rxjs";
import { LoginRequest, LoginResponse, RegisterRequest } from "../models/login";
import { BaseResponse } from "../models/base";

export abstract class AuthGateway {
    abstract login(request: LoginRequest): Observable<BaseResponse<LoginResponse>>
    abstract register(request: RegisterRequest): Observable<BaseResponse<LoginResponse>>
}