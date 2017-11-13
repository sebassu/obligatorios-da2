import { Observable } from 'rxjs/Observable';
import { LoginService } from './login-service';
import { Http, Response } from '@angular/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [LoginService]
})
export class LoginComponent {

  errorOcurred: boolean;
  errorMessage: string;
  success: boolean;

  username: string;
  password: string;

  constructor(private _loginService: LoginService) {
    this.success = false;
    this.errorOcurred = false;
  }

  attemptToLoginUser() {
    try {
      this._loginService.attemptLoginWithData(this.username,
        this.password);
      this.success = true;
      setTimeout(() => {
        this._loginService.naviagateHome();
      }, 2000);
    } catch (error) {
      this.errorMessage = (<Error>error).message;
      this.errorOcurred = true;
    }
  }
}