import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';
import { AuthService } from '../authentication/auth.service';
import { UserRole } from '../authentication/user-roles';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  userRole!: Observable<UserRole>;

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) {}

  ngOnInit(): void {
    this.getAuthenticationData();
    console.log(window.location.origin);
  }

  private getAuthenticationData() {
    this.userRole = this.authService.currentUserRole;
  }

  /**
   * Kisebb képernyős nézetnél a menü lenyitása és bezárása.
   */
  toggle() {
    this.isExpanded = !this.isExpanded;
    this.authService.logout();
  }

  /**
   * A felhasználó átnavigálása a bejelentkezési oldalra.
   */
  login() {
    this.spinner.show();
    this.authService.login();
  }

  /**
   * A felhasználó átnavigálása a regisztrációs oldalra.
   */
  register() {
    this.spinner.show();
    this.authService.register();
  }

  /**
   * A felhasználó átnavigálása a profil oldalra.
   */
  navigateToProfile() {
    this.spinner.show();
    this.authService.navigateToProfilePage();
  }

  /**
   * A felhasználó átnavigálása a kijelentkezési oldalra.
   */
  logout() {
    this.spinner.show();
    this.authService.logout();
  }
}
