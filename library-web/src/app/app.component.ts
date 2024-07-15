import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './presentation/common/navbar/navbar.component';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { heroPlusCircleSolid, heroTrashSolid } from '@ng-icons/heroicons/solid';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, NavbarComponent, NgIconComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
}
