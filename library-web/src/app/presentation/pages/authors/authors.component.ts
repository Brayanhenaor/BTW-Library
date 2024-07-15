import { Author } from '../../../domain/models/author';
import { BaseResponse } from '../../../domain/models/base';
import { AuthorsApiService } from './../../../infraestructure/api/authors.service';
import { Component, OnInit } from '@angular/core';
import { AuthorItemComponent } from './author-item/author-item.component';
import { AuthorUsesCases } from '../../../domain/usecases/author.usecase';
import { AddAuthorComponent } from './add-author/add-author.component';
import { ToastrService } from 'ngx-toastr';
import { NgIconsModule } from '@ng-icons/core';

@Component({
  selector: 'app-authors',
  standalone: true,
  imports: [AuthorItemComponent, AddAuthorComponent, NgIconsModule],
  templateUrl: './authors.component.html',
  styleUrl: './authors.component.css'
})
export class AuthorsComponent implements OnInit {
  authors: Author[] = []
  showAdd: boolean = false

  constructor(
    private authorUseCases: AuthorUsesCases,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.getAuthors();
  }

  private getAuthors() {
    this.authorUseCases.getAuthors().subscribe((data: BaseResponse<Author[]>) => {
      this.authors = data.Data
    })
  }

  handleAdd() {
    this.showAdd = true
  }

  handleDelete(id: string) {
    this.authorUseCases.deleteAuthor(id).subscribe(_ => {
      this.ngOnInit()
      this.toastr.success('Autor eliminado', 'Exito');
    })
  }
}
