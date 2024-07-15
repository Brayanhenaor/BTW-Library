export interface Author {
    id: string;
    firstName: string;
    lastName: string;
    document: string;
    booksCount: number
}

export interface AuthorRequest {
    firstName: string;
    lastName: string;
    document: string;
}