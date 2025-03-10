import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../infraestructure/services/auth.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(
    private authService: AuthService,
    private router: Router
  ) {
  }

  closeSesion(){
    this.authService.logout()
    this.router.navigate(['/login'])
  }
}
