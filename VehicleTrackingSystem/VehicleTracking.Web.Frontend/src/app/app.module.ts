import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { OptionsMenuComponent } from './options-menu/options-menu.component';
import { RouterModule } from '@angular/router';
import { IsLoggedGuard } from './guards/is-logged-guard';
import { IsNotLoggedGuard } from './guards/is-not-logged-guard';
import { TransportComponent } from './register-transport/transport.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { LotListComponent } from './lot-list/lot-list.component';
import { TransportListComponent } from './transport-list/transport-list.component';
import { MovementComponent } from './movement/movement.component';
import { PortInspectionComponent } from './port-inspection/port-inspection.component';
import { YardInspectionComponent } from './yard-inspection/yard-inspection.component';
import { LotComponent } from './register-lot/lot.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TransportComponent,
    OptionsMenuComponent,
    VehicleListComponent,
    LotListComponent,
    LotComponent,
    TransportListComponent,
    MovementComponent,
    PortInspectionComponent,
    YardInspectionComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      {
        path: 'app', component: OptionsMenuComponent,
        children: [
          { path: 'registerLot', component: LotComponent, pathMatch: 'prefix' },
          { path: 'registerPortInspection', component: PortInspectionComponent, pathMatch: 'prefix' },
          { path: 'registerTransport', component: TransportComponent, pathMatch: 'prefix' },
          { path: 'registerYardInspection', component: YardInspectionComponent, pathMatch: 'prefix' },
          { path: 'transports', component: TransportListComponent, pathMatch: 'prefix' },
          { path: 'vehicles', component: VehicleListComponent, pathMatch: 'prefix' },
          { path: 'lots', component: LotListComponent, pathMatch: 'prefix' },
          { path: 'movements', component: MovementComponent, pathMatch: 'prefix' }
        ]
      },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ])
  ],
  providers: [IsLoggedGuard, IsNotLoggedGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }