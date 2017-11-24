import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../entities/vehicle';
import { LotService } from '../services/lot.service';
import { Lot } from '../entities/lot';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lot-list',
  templateUrl: './lot-list.component.html',
  styleUrls: ['../styles/list-styles.css']
})
export class LotListComponent implements OnInit {

  lots: Array<Lot>;
  selectedLot: Lot;

  constructor(private _lotService: LotService,
    private _router: Router) {
    this.lots = [];
    this.selectedLot = null;
  }

  ngOnInit(): void {
    this._lotService.getLots()
      .subscribe(lotsObtained => this.lots = lotsObtained);
  }

  private setSelectedLot(someLot: Lot) {
    this.selectedLot = someLot;
  }

  private deleteLot() {
    let result = confirm("¿Está seguro que desea eliminar al lote seleccionado?");
    if (result) {
      this._lotService.deleteLotWithName(this.selectedLot.name);
    }
  }

  private editLot() {
    this._router.navigate(['/app/editLot', this.selectedLot.name]);
  }
}