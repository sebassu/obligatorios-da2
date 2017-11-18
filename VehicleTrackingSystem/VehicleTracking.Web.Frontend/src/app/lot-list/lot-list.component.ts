import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { LotService } from '../services/lot.service';
import { Lot } from '../entities/lot';

@Component({
  selector: 'app-lot-list',
  templateUrl: './lot-list.component.html',
  styleUrls: ['../styles/list-styles.css']
})
export class LotListComponent implements OnInit {

  lots: Array<Lot>;

  constructor(private _lotService: LotService) {
    this.lots = [];
  }

  ngOnInit(): void {
    this._lotService.getLots()
      .subscribe(lotsObtained => this.lots = lotsObtained);
  }
}