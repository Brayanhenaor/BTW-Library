export interface BaseResponse<T> {
    Success: boolean;
    Message: string;
    Data: T;
}