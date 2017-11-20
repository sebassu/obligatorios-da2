import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { OptionsMenuComponent } from './options-menu/options-menu.component';
import { RouterModule } from '@angular/router';
import { IsNotLoggedGuard } from './guards/is-not-logged-guard';
import { TransportComponent } from './register-transport/transport.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { LotListComponent } from './lot-list/lot-list.component';
import { TransportListComponent } from './transport-list/transport-list.component';
import { MovementComponent } from './movement/movement.component';
import { PortInspectionComponent } from './port-inspection/port-inspection.component';
import { YardInspectionComponent } from './yard-inspection/yard-inspection.component';
import { LotComponent } from './register-lot/lot.component';
import { IsLoggedGuard } from './guards/is-logged-guard';
import { HasPortPrivilegesGuard } from './guards/has-port-privileges-guard';
import { HasTrasportPrivilegesGuard } from './guards/has-transport-privileges-guard';
import { HasYardPrivilegesGuard } from './guards/has-yard-privileges-guard';
import { HasSalePrivilegesGuard } from './guards/has-sale-privileges-guard';
import { CanViewRegisteredLotsGuard } from './guards/can-view-registered-lots-guard';

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
      { path: 'login', component: LoginComponent, canActivate: [IsNotLoggedGuard] },
      {
        path: 'app', component: OptionsMenuComponent, canActivate: [IsLoggedGuard],
        children: [
          {
            path: 'registerLot', component: LotComponent,
            canActivate: [HasPortPrivilegesGuard], pathMatch: 'prefix'
          },
          {
            path: 'registerPortInspection', component: PortInspectionComponent,
            canActivate: [HasPortPrivilegesGuard], pathMatch: 'prefix'
          },
          {
            path: 'registerTransport', component: TransportComponent,
            canActivate: [HasTrasportPrivilegesGuard], pathMatch: 'prefix'
          },
          {
            path: 'registerYardInspection', component: YardInspectionComponent,
            canActivate: [HasYardPrivilegesGuard], pathMatch: 'prefix'
          },
          {
            path: 'transports', component: TransportListComponent,
            canActivate: [HasTrasportPrivilegesGuard], pathMatch: 'prefix'
          },
          {
            path: 'vehicles', component: VehicleListComponent,
            canActivate: [IsLoggedGuard], pathMatch: 'prefix'
          },
          {
            path: 'lots', component: LotListComponent,
            canActivate: [CanViewRegisteredLotsGuard], pathMatch: 'prefix'
          },
          {
            path: 'registerMovement', component: MovementComponent,
            canActivate: [HasYardPrivilegesGuard], pathMatch: 'prefix'
          }
        ]
      },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: '**', redirectTo: 'login', pathMatch: 'full' }
    ])
  ],
  providers: [IsNotLoggedGuard, IsLoggedGuard, HasPortPrivilegesGuard, HasTrasportPrivilegesGuard,
    HasYardPrivilegesGuard, HasSalePrivilegesGuard, CanViewRegisteredLotsGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }