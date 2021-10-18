import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd/notification';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validateForm!: FormGroup;

  showAuthenticationError: boolean = false;
  authenticationError: string = "";

  constructor(
    private fb: FormBuilder,
    private notification: NzNotificationService,
    private _authService: AuthService,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      UserName: [null, [Validators.required]],
      Password: [null, [Validators.required]],
    });
  }

  login() {
    if (this.validateForm.valid) {
      this._authService.logIn(this.validateForm.value)
        .subscribe(event => {
          if (event.type === HttpEventType.Sent) {
          }
          if (event.type === HttpEventType.Response) {
            console.log(event.body)
            localStorage.setItem('token', event.body['token']);
            this._router.navigate(['/announcements']);
          }
        },
          error => {
            this.authenticationError = error.error.message;
          })
    }
  }
}
