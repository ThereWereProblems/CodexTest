import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html'
})
export class LoginFormComponent {
  username = '';
  password = '';

  constructor(private http: HttpClient, private router: Router) { }

  login() {
    this.http.post<{ token: string }>('/api/auth/login', { username: this.username, password: this.password })
      .subscribe({
        next: res => {
          localStorage.setItem('token', res.token);
          this.router.navigate(['/']);
        },
        error: () => alert('Login failed')
      });
  }
}
