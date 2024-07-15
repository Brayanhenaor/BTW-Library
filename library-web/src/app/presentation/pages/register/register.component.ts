import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthUsesCases } from '../../../domain/usecases/loginUseCases';
import { BaseResponse } from '../../../domain/models/base';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authUseCases: AuthUsesCases,
    private router: Router
  ) {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  submitForm() {
    if (this.registerForm.valid) {
      this.handleRegister();
    }
  }

  handleRegister(): void {
    const { username, password, email } = this.registerForm.value;
    this.authUseCases.register({ email, username, password }).subscribe((data: BaseResponse<any>) => {
      this.router.navigate(['/login'])
    });;
  }
}
