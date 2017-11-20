import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { environment } from '../../environments/environment.prod';

@Component({
  selector: 'options-menu',
  templateUrl: './options-menu.component.html',
  styleUrls: ['./options-menu.component.css']
})
export class OptionsMenuComponent implements OnInit {

  userHasNoPortPrivileges: boolean;
  userHasNoTransportPrivileges: boolean;
  userHasNoYardPrivileges: boolean;
  userHasNoSalePrivileges: boolean;
  userHasNoLotVisualizationPrivileges: boolean;

  constructor(private _router: Router) { }

  ngOnInit(): void {
    let userRole = sessionStorage.getItem("role");
    let isNotAdministrator = userRole !== environment.ADMINISTRATOR_ROLE;
    this.userHasNoPortPrivileges = isNotAdministrator &&
      userRole !== environment.PORT_ROLE;
    this.userHasNoTransportPrivileges = isNotAdministrator &&
      userRole !== environment.TRANSPORTER_ROLE;
    this.userHasNoYardPrivileges = isNotAdministrator &&
      userRole !== environment.YARD_ROLE;
    this.userHasNoSalePrivileges = isNotAdministrator &&
      userRole !== environment.SALESMAN_ROLE;
    this.userHasNoLotVisualizationPrivileges = this.userHasNoPortPrivileges
      && this.userHasNoTransportPrivileges;
  }

  private processLogout() {
    sessionStorage.clear();
    this._router.navigate(["/login"]);
  }
}