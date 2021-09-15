import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from './authentication/auth.service';
import { TopsecretService } from './topsecret.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthService, private secret: TopsecretService, private spinner: NgxSpinnerService) {}

  ngOnInit() {
    if (!this.authService.hasValidToken()) {
      this.spinner.show();
      this.authService.login();
      this.authService.tokenReceivedEvent().toPromise().finally(() => this.spinner.hide());
    }
    this.secret.fetchTopSecretData().subscribe(result => {
      console.log(result);
    });
  }
}