import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Observable } from 'rxjs';
import { AuthService } from '../authentication/auth.service';
import { UserRole } from '../authentication/models/user-roles';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit {
  /** A navigációs menü lenyitása. */
  isExpanded = false;

  /** Az aktuális felhasználó szerepköre. */
  userRole: Observable<UserRole> = new Observable();

  constructor(
    private authService: AuthService,
    private spinner: NgxSpinnerService
  ) {}

  ngOnInit(): void {
    this.spinner.hide();
    this.getAuthenticationData();
  }

  private getAuthenticationData() {
    this.userRole = this.authService.currentUserRole;
  }

  /**
   * Kisebb képernyős nézetnél a menü lenyitása és bezárása.
   */
  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  /**
   * A felhasználó átnavigálása a bejelentkezési oldalra.
   */
  login() {
    this.spinner.show();
    this.authService.login();
  }

  /**
   * A felhasználó átnavigálása a profil oldalra.
   */
  navigateToProfile() {
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
