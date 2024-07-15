import { Author } from "./author";

export interface BookResponse {
    id: string;
    dateAdded: Date;
    title: string;
    publishedDate: Date;
    authorId: string;
    isAvailable: boolean;
    author: Author;
}

export interface BookRequest {
    title: string;
    publishedDate: Date;
    authorId: string;
    isAvailable: boolean;
}