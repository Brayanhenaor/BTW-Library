import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Author } from '../../../../domain/models/author';
import { NgIconsModule } from '@ng-icons/core';

@Component({
  selector: 'app-author-item',
  standalone: true,
  imports: [NgIconsModule],
  templateUrl: './author-item.component.html',
  styleUrl: './author-item.component.css'
})
export class AuthorItemComponent {
  @Input()
  author: Author | null = null;

  @Output()
  delete = new EventEmitter<string>()
}
