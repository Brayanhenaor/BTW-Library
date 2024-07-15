import { AuthorUsesCases } from './../../../../domain/usecases/authorUseCases';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BaseResponse } from '../../../../domain/models/base';
import { Author } from '../../../../domain/models/author';
import { BooksUsesCases } from '../../../../domain/usecases/booksUseCases';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent implements OnInit {
  addBookForm: FormGroup;
  authors: Author[] = []
  @Output()
  close = new EventEmitter()

  @Output()
  added = new EventEmitter()

  constructor(
    private formBuilder: FormBuilder,
    private authorUsesCases: AuthorUsesCases,
    private booksUseCases: BooksUsesCases,
    private toastr: ToastrService
  ) {
    this.addBookForm = this.formBuilder.group({
      title: ['', Validators.required],
      publishedDate: [new Date(), Validators.required],
      authorId: ['', Validators.required]
    });
  }
  ngOnInit(): void {
    this.getAuthors()
  }

  handleClose() {
    this.close.emit();
  }

  private getAuthors() {
    this.authorUsesCases.getAuthors().subscribe((data: BaseResponse<Author[]>) => {
      this.authors = data.Data
    })
  }

  submitForm() {
    const { title, publishedDate, authorId } = this.addBookForm.value
    this.booksUseCases.addBook({
      title: title,
      publishedDate: publishedDate,
      authorId: authorId,
      isAvailable: true
    }).subscribe(_ => {
      this.toastr.success('Libro Agregado', 'Exito');
      this.close.emit()
      this.added.emit()
    })
  }
}
