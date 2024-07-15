import { BookItemComponent } from './book-item/book-item.component';
import { Component, OnInit } from '@angular/core';
import { BooksUsesCases } from '../../../domain/usecases/booksUseCases';
import { LoanUsesCases } from '../../../domain/usecases/loanUseCases';
import { BookResponse } from '../../../domain/models/book';
import { BaseResponse } from '../../../domain/models/base';
import { HttpClientModule } from '@angular/common/http';
import { Loan } from '../../../domain/models/loan';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { AddBookComponent } from './add-book/add-book.component';
import { NgIconComponent } from '@ng-icons/core';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [HttpClientModule, BookItemComponent, DatePipe, AddBookComponent, NgIconComponent],
  templateUrl: './books.component.html',
  styleUrl: './books.component.css'
})
export class BooksComponent implements OnInit {
  books: BookResponse[] = []
  loans: Loan[] = []
  showAdd: boolean = false

  constructor(
    private _booksUseCases: BooksUsesCases,
    private _loanUsesCases: LoanUsesCases,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.getAllBooks()
    this.getMyReservations()
  }

  private getAllBooks() {
    let result = this._booksUseCases.getBooks();
    result.subscribe((data: BaseResponse<BookResponse[]>) => {
      this.books = data.Data
    })
  }

  private getMyReservations() {
    let result = this._loanUsesCases.getMyReservations();
    result.subscribe((data: BaseResponse<Loan[]>) => {
      this.loans = data.Data
    })
  }

  returnBook(id: string) {
    this._loanUsesCases.returnBook(id).subscribe(_ => {
      this.toastr.success('Libro devuelto', 'Exito');
      this.ngOnInit()
    })
  }

  delete(id: string) {
    this._booksUseCases.deleteBook(id).subscribe(_ => {
      this.toastr.success('Libro eliminado', 'Exito');
      this.ngOnInit()
    })
  }

  reserve(bookId: string) {
    this._loanUsesCases.reserve(bookId).subscribe(_ => {
      this.toastr.success('Libro prestado', 'Exito');
      this.ngOnInit()
    })
  }

  handleAdd() {
    this.showAdd = true
  }

}
