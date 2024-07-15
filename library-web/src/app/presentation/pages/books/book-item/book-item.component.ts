import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BookResponse } from '../../../../domain/models/book';
import { DatePipe } from '@angular/common';
import { NgIconComponent } from '@ng-icons/core';

@Component({
  selector: 'app-book-item',
  standalone: true,
  imports: [DatePipe, NgIconComponent],
  templateUrl: './book-item.component.html',
  styleUrl: './book-item.component.css'
})
export class BookItemComponent {
  @Input()
  book: BookResponse | null = null;

  @Output()
  reserve = new EventEmitter<string>()

  @Output()
  delete = new EventEmitter<string>()

  reserveBook(id: string) {
    this.reserve.emit(id);
  }
  deleteBook(id: string) {
    this.delete.emit(id);
  }
}
