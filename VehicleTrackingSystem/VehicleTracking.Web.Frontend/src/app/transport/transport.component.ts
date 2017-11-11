import { Component } from '@angular/core';

@Component({
  selector: 'transport-component',
  templateUrl: './transport.component.html',
  styleUrls: ['./transport.component.css']
})
export class TransportComponent {
  
  id: number;
  transporterUsername: string = "UnUsuario";
  startDateTime: Date;
  transportedLotsNames: Array<string>;
  endDateTime: Date
  
  constructor(){}

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
