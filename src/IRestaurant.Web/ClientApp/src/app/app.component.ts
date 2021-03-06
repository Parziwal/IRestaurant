import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private http: HttpClient) {
    this.http.get("https://localhost:44312/api/restaurants/myrestaurant/3").subscribe(
      (res) => console.log(res)
    );
  }
}
