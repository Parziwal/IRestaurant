import { Component, OnInit } from '@angular/core';
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

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
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
}
