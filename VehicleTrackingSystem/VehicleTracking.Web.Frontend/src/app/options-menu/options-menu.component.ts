import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'options-menu',
  templateUrl: './options-menu.component.html',
  styleUrls: ['./options-menu.component.css']
})
export class OptionsMenuComponent implements OnInit {

  constructor(private _router: Router) { }

  private processLogout() {
    localStorage.clear();
    this._router.navigate(["/login"]);
  }

  ngOnInit() {
  }

}
