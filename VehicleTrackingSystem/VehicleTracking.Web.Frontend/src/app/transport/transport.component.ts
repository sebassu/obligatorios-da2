import { Component, OnInit } from '@angular/core';
import { LotService } from '../lot/lot.service';
import { Lot } from '../lot/lot';


@Component({
  selector: 'transport-component',
  templateUrl: './transport.component.html',
  styleUrls: ['./transport.component.css']
})
export class TransportComponent implements OnInit{
  id: number;
  transporterUsername: string;
  startDateTime: Date;
  transportedLotsNames: Array<string>;
  endDateTime: Date;
  availableLots:Array<Lot>;
  errorMessage: string;
  
  constructor(private _lotService: LotService){}

  ngOnInit(): void {
    this._lotService.getLots()
            .subscribe(lotsObtained => this.availableLots = lotsObtained,
              error => this.errorMessage = <any>error);
}

  checkLot(): void {
    var list = document.querySelector('ul');
    list.addEventListener('click', function(ev) {
      var element = ev.target as HTMLElement;   
      if (element.tagName === 'LI') {
        element.classList.toggle('checked');
      }
    }, false);
  }

  beginTransport():void{

  }

}
