import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from '../../common/navbar/navbar.component';

@Component({
  selector: 'app-logged-layout',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent],
  templateUrl: './logged-layout.component.html',
  styleUrl: './logged-layout.component.css'
})
export class LoggedLayoutComponent {

}
