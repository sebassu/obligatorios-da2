import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { TransportComponent } from './transport/transport.component';


@NgModule({
  imports: [ BrowserModule ],
  declarations: [ AppComponent, TransportComponent ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
