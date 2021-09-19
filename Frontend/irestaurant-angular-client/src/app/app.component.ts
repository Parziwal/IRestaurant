import { Component, OnInit } from '@angular/core';
import { OAuthErrorEvent, OAuthService } from 'angular-oauth2-oidc';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from './authentication/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    this.spinner.show();
    if (!this.authService.hasValidToken()) {
      this.spinner.show();
      this.authService.login();
      this.authService.tokenReceivedEvent().toPromise().finally(() => console.log("jj"));
    }
  }
}