import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.css']
})
export class AuthCallbackComponent implements OnInit {

  authError = false; 

  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  async ngOnInit() {
    if (this.route.snapshot.fragment != null && this.route.snapshot.fragment.indexOf('error') >= 0) {
      this.authError=true; 
      return;    
    }
    
    await this.authService.completeAuthentication();      
    this.router.navigate(['/']);   
  }

}
