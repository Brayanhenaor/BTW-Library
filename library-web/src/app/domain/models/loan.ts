export interface Loan {
    userId: string;
    bookName: string;
    id: string;
    userEmail: string;
    bookId: string;
    loanDate: Date;
    returnDate: Date;
}

export interface Reservation{
    reservationId: string;
}