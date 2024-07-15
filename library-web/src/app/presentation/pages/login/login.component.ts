import { BaseResponse } from './../../../domain/models/base';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthUsesCases } from '../../../domain/usecases/loginUseCases';
import { Observable } from 'rxjs';
import { LoginResponse } from '../../../domain/models/login';
import { AuthService } from '../../../infraestructure/services/auth.service';
import { Router } from '@angular/router'; // Importa el Router

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  response$: Observable<BaseResponse<LoginResponse>> | undefined;
  datos?: BaseResponse<LoginResponse>;

  constructor(
    private formBuilder: FormBuilder,
    private _loginUseCase: AuthUsesCases,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void { }

  submitForm(): void {
    if (this.loginForm.valid) {
      this.handleLogin();
    }
  }

  handleLogin(): void {
    const { username, password } = this.loginForm.value;
    this.response$ = this._loginUseCase.login({ username, password });

    this.response$.subscribe((data: BaseResponse<LoginResponse>) => {
      this.datos = data;
      if (data.Data.token) {
        this.authService.setToken(data.Data.token);
        this.router.navigate(['/books']);
      }
    });
  }

  handleRegister() {
    this.router.navigate(['/register'])
  }
}
