import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faGithub } from '@fortawesome/free-brands-svg-icons';
import { faBook, faCircleHalfStroke, faMoon, faSun } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [FontAwesomeModule,RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit{
  public sunIcon = faSun;
  public moonIcon = faMoon;
  public autoIcon = faCircleHalfStroke;
  public selectedIcon = this.moonIcon;
  public githubIcon = faGithub;
  public docsIcon = faBook;
  

  public ngOnInit(): void {
    
    const theme = this.getPreferredTheme();

    this.setTheme(theme);
    localStorage.setItem('theme', theme);
    this.changeIcon(theme);
  }

  public toggleTheme(theme:string): void {
    
    localStorage.setItem('theme', theme)
    this.setTheme(theme);
    this.changeIcon(theme);

  }

  public getPreferredTheme(): string {

    const storedTheme = localStorage.getItem('theme');

    if (storedTheme) {
      return storedTheme
    }

    return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
  }

  public setTheme(theme: string): void {
    if (theme === 'auto' && window.matchMedia('(prefers-color-scheme: dark)').matches) {
      document.documentElement.setAttribute('data-bs-theme', 'dark')
    } else {
      document.documentElement.setAttribute('data-bs-theme', theme)
    }
  }

  public changeIcon(theme:string): void {
    if (theme === 'dark') {
      this.selectedIcon = this.moonIcon;
    } else if (theme === 'light') {
      this.selectedIcon = this.sunIcon;
    } else {
      this.selectedIcon = this.autoIcon;
    }
  }

}
