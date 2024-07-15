import { Component, EventEmitter, Output } from '@angular/core';
import { AuthorUsesCases } from '../../../../domain/usecases/authorUseCases';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-author',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-author.component.html',
  styleUrl: './add-author.component.css'
})
export class AddAuthorComponent {
  addAuthorForm: FormGroup;

  @Output()
  close = new EventEmitter()

  @Output()
  added = new EventEmitter()

  constructor(
    private formBuilder: FormBuilder,
    private authorUsesCases: AuthorUsesCases,
    private toastr: ToastrService
  ) {
    this.addAuthorForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      document: ['', Validators.required]
    });
  }

  handleClose() {
    this.close.emit();
  }

  submitForm() {
    const { firstName, lastName, document } = this.addAuthorForm.value
    this.authorUsesCases.addAuthor({
      firstName,
      lastName,
      document
    }).subscribe(_ => {
      this.toastr.success('Autor Agregado', 'Exito');
      this.added.emit()
      this.handleClose()
    })
  }
}
