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
import { TransportComponent } from './transport/transport.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TransportComponent,
    OptionsMenuComponent,
    VehicleListComponent
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
          { path: 'registerTransport', component: TransportComponent, pathMatch: 'prefix' },
          { path: 'vehicles', component: VehicleListComponent, pathMatch: 'prefix' }
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