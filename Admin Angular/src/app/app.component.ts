import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth/auth.service';
import { CurrentUser } from './services/auth/auth.types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isCollapsed = false;
  showMenuItems: boolean;
  loggedInUser: CurrentUser;


  constructor(
    private _router: Router,
    private _authService: AuthService
  ) {
    this.getUserDetails();

   }

  ngOnInit() {
    this._router.events.subscribe(event => this.modifyMenuItems(event));
  }

  openMap: { [name: string]: boolean } = {
    sub1: false,
    sub2: false,
    sub3: false,
    sub4: false,
    sub5: false,
    sub6: false,
    sub7: false,
    sub8: false,
    sub9: false,
    sub10: false,
    sub11: false,
    sub12: false,
  };

  openHandler(value: string): void {
    for (const key in this.openMap) {
      if (key !== value) {
        this.openMap[key] = false;
      }
    }
  }

  modifyMenuItems(location) {
    if (
      window.location.pathname == "/" ||
      window.location.pathname == "/login" ||
      window.location.pathname == "/reset-password"
    ) {
      this.showMenuItems = false;
    }
    else {
      this.showMenuItems = true;
    }
  }

  onLogOut(){
    this._authService.signOut();
    this._router.navigate(['']);
  }


  private getUserDetails() {
    this.loggedInUser = this._authService.currentUser;
  }

}
