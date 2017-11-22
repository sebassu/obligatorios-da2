import { Component, OnInit } from '@angular/core';
import { Sale } from '../entities/sale';
import { SaleService } from '../services/saleService';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['../styles/list-styles.css']
})
export class SaleListComponent implements OnInit {

  sales: Array<Sale>;

  constructor(private _saleService: SaleService) {
    this.sales = [];
  }

  ngOnInit(): void {
    this._saleService.getSales()
      .subscribe(salesObtained => this.sales = salesObtained);
  }
}