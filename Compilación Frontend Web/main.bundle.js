webpackJsonp(["main"],{

/***/ "../../../../../src/$$_lazy_route_resource lazy recursive":
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncatched exception popping up in devtools
	return Promise.resolve().then(function() {
		throw new Error("Cannot find module '" + req + "'.");
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "../../../../../src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_lot_service__ = __webpack_require__("../../../../../src/app/services/lot.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_transport_service__ = __webpack_require__("../../../../../src/app/services/transport.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__services_subzone_service__ = __webpack_require__("../../../../../src/app/services/subzone.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__services_location_service__ = __webpack_require__("../../../../../src/app/services/location.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__ = __webpack_require__("../../../../../src/app/services/inspection.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__services_movement_service__ = __webpack_require__("../../../../../src/app/services/movement.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__services_login_service__ = __webpack_require__("../../../../../src/app/services/login-service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__services_saleService__ = __webpack_require__("../../../../../src/app/services/saleService.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};










var AppComponent = (function () {
    function AppComponent() {
        this.title = 'app';
    }
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-root',
            template: '<router-outlet></router-outlet>',
            providers: [__WEBPACK_IMPORTED_MODULE_1__services_lot_service__["a" /* LotService */], __WEBPACK_IMPORTED_MODULE_2__services_transport_service__["a" /* TransportService */], __WEBPACK_IMPORTED_MODULE_3__services_vehicle_service__["a" /* VehicleService */], __WEBPACK_IMPORTED_MODULE_4__services_subzone_service__["a" /* SubzoneService */],
                __WEBPACK_IMPORTED_MODULE_5__services_location_service__["a" /* LocationService */], __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__["a" /* InspectionService */], __WEBPACK_IMPORTED_MODULE_7__services_movement_service__["a" /* MovementService */], __WEBPACK_IMPORTED_MODULE_8__services_login_service__["a" /* LoginService */], __WEBPACK_IMPORTED_MODULE_9__services_saleService__["a" /* SaleService */]]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/esm5/forms.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__app_component__ = __webpack_require__("../../../../../src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__login_login_component__ = __webpack_require__("../../../../../src/app/login/login.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__options_menu_options_menu_component__ = __webpack_require__("../../../../../src/app/options-menu/options-menu.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__guards_is_not_logged_guard__ = __webpack_require__("../../../../../src/app/guards/is-not-logged-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__register_transport_transport_component__ = __webpack_require__("../../../../../src/app/register-transport/transport.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__vehicle_list_vehicle_list_component__ = __webpack_require__("../../../../../src/app/vehicle-list/vehicle-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__lot_list_lot_list_component__ = __webpack_require__("../../../../../src/app/lot-list/lot-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__transport_list_transport_list_component__ = __webpack_require__("../../../../../src/app/transport-list/transport-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__register_movement_movement_component__ = __webpack_require__("../../../../../src/app/register-movement/movement.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__register_port_inspection_port_inspection_component__ = __webpack_require__("../../../../../src/app/register-port-inspection/port-inspection.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__register_yard_inspection_yard_inspection_component__ = __webpack_require__("../../../../../src/app/register-yard-inspection/yard-inspection.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__register_lot_lot_component__ = __webpack_require__("../../../../../src/app/register-lot/lot.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__guards_is_logged_guard__ = __webpack_require__("../../../../../src/app/guards/is-logged-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_18__guards_has_port_privileges_guard__ = __webpack_require__("../../../../../src/app/guards/has-port-privileges-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_19__guards_has_transport_privileges_guard__ = __webpack_require__("../../../../../src/app/guards/has-transport-privileges-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_20__guards_has_yard_privileges_guard__ = __webpack_require__("../../../../../src/app/guards/has-yard-privileges-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_21__guards_has_sale_privileges_guard__ = __webpack_require__("../../../../../src/app/guards/has-sale-privileges-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_22__guards_can_view_registered_lots_guard__ = __webpack_require__("../../../../../src/app/guards/can-view-registered-lots-guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_23__register_sale_sale_component__ = __webpack_require__("../../../../../src/app/register-sale/sale.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_24__sale_list_sale_list_component__ = __webpack_require__("../../../../../src/app/sale-list/sale-list.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_25__vehicle_history_vehicle_history_component__ = __webpack_require__("../../../../../src/app/vehicle-history/vehicle-history.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_26__edit_lot_edit_lot_component__ = __webpack_require__("../../../../../src/app/edit-lot/edit-lot.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



























var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["I" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_4__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_5__login_login_component__["a" /* LoginComponent */],
                __WEBPACK_IMPORTED_MODULE_9__register_transport_transport_component__["a" /* TransportComponent */],
                __WEBPACK_IMPORTED_MODULE_6__options_menu_options_menu_component__["a" /* OptionsMenuComponent */],
                __WEBPACK_IMPORTED_MODULE_10__vehicle_list_vehicle_list_component__["a" /* VehicleListComponent */],
                __WEBPACK_IMPORTED_MODULE_11__lot_list_lot_list_component__["a" /* LotListComponent */],
                __WEBPACK_IMPORTED_MODULE_16__register_lot_lot_component__["a" /* LotComponent */],
                __WEBPACK_IMPORTED_MODULE_12__transport_list_transport_list_component__["a" /* TransportListComponent */],
                __WEBPACK_IMPORTED_MODULE_13__register_movement_movement_component__["a" /* MovementComponent */],
                __WEBPACK_IMPORTED_MODULE_14__register_port_inspection_port_inspection_component__["a" /* PortInspectionComponent */],
                __WEBPACK_IMPORTED_MODULE_15__register_yard_inspection_yard_inspection_component__["a" /* YardInspectionComponent */],
                __WEBPACK_IMPORTED_MODULE_23__register_sale_sale_component__["a" /* SaleComponent */],
                __WEBPACK_IMPORTED_MODULE_24__sale_list_sale_list_component__["a" /* SaleListComponent */],
                __WEBPACK_IMPORTED_MODULE_25__vehicle_history_vehicle_history_component__["a" /* VehicleHistoryComponent */],
                __WEBPACK_IMPORTED_MODULE_26__edit_lot_edit_lot_component__["a" /* EditLotComponent */]
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_http__["c" /* HttpModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_forms__["a" /* FormsModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_forms__["b" /* ReactiveFormsModule */],
                __WEBPACK_IMPORTED_MODULE_7__angular_router__["c" /* RouterModule */].forRoot([
                    { path: 'login', component: __WEBPACK_IMPORTED_MODULE_5__login_login_component__["a" /* LoginComponent */], canActivate: [__WEBPACK_IMPORTED_MODULE_8__guards_is_not_logged_guard__["a" /* IsNotLoggedGuard */]] },
                    {
                        path: 'app', component: __WEBPACK_IMPORTED_MODULE_6__options_menu_options_menu_component__["a" /* OptionsMenuComponent */], canActivate: [__WEBPACK_IMPORTED_MODULE_17__guards_is_logged_guard__["a" /* IsLoggedGuard */]],
                        children: [
                            {
                                path: 'registerLot', component: __WEBPACK_IMPORTED_MODULE_16__register_lot_lot_component__["a" /* LotComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_18__guards_has_port_privileges_guard__["a" /* HasPortPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'registerPortInspection', component: __WEBPACK_IMPORTED_MODULE_14__register_port_inspection_port_inspection_component__["a" /* PortInspectionComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_18__guards_has_port_privileges_guard__["a" /* HasPortPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'registerTransport', component: __WEBPACK_IMPORTED_MODULE_9__register_transport_transport_component__["a" /* TransportComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_19__guards_has_transport_privileges_guard__["a" /* HasTrasportPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'registerYardInspection', component: __WEBPACK_IMPORTED_MODULE_15__register_yard_inspection_yard_inspection_component__["a" /* YardInspectionComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_20__guards_has_yard_privileges_guard__["a" /* HasYardPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'transports', component: __WEBPACK_IMPORTED_MODULE_12__transport_list_transport_list_component__["a" /* TransportListComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_19__guards_has_transport_privileges_guard__["a" /* HasTrasportPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'vehicles', component: __WEBPACK_IMPORTED_MODULE_10__vehicle_list_vehicle_list_component__["a" /* VehicleListComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_17__guards_is_logged_guard__["a" /* IsLoggedGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'lots', component: __WEBPACK_IMPORTED_MODULE_11__lot_list_lot_list_component__["a" /* LotListComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_22__guards_can_view_registered_lots_guard__["a" /* CanViewRegisteredLotsGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'registerMovement', component: __WEBPACK_IMPORTED_MODULE_13__register_movement_movement_component__["a" /* MovementComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_20__guards_has_yard_privileges_guard__["a" /* HasYardPrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'sales', component: __WEBPACK_IMPORTED_MODULE_24__sale_list_sale_list_component__["a" /* SaleListComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_21__guards_has_sale_privileges_guard__["a" /* HasSalePrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'registerSale', component: __WEBPACK_IMPORTED_MODULE_23__register_sale_sale_component__["a" /* SaleComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_21__guards_has_sale_privileges_guard__["a" /* HasSalePrivilegesGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'vehicleHistory/:vehicleVIN', component: __WEBPACK_IMPORTED_MODULE_25__vehicle_history_vehicle_history_component__["a" /* VehicleHistoryComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_17__guards_is_logged_guard__["a" /* IsLoggedGuard */]], pathMatch: 'prefix'
                            },
                            {
                                path: 'editLot/:lotName', component: __WEBPACK_IMPORTED_MODULE_26__edit_lot_edit_lot_component__["a" /* EditLotComponent */],
                                canActivate: [__WEBPACK_IMPORTED_MODULE_18__guards_has_port_privileges_guard__["a" /* HasPortPrivilegesGuard */]], pathMatch: 'prefix'
                            }
                        ]
                    },
                    { path: '', redirectTo: 'login', pathMatch: 'full' },
                    { path: '**', redirectTo: 'login', pathMatch: 'full' }
                ])
            ],
            providers: [__WEBPACK_IMPORTED_MODULE_8__guards_is_not_logged_guard__["a" /* IsNotLoggedGuard */], __WEBPACK_IMPORTED_MODULE_17__guards_is_logged_guard__["a" /* IsLoggedGuard */], __WEBPACK_IMPORTED_MODULE_18__guards_has_port_privileges_guard__["a" /* HasPortPrivilegesGuard */], __WEBPACK_IMPORTED_MODULE_19__guards_has_transport_privileges_guard__["a" /* HasTrasportPrivilegesGuard */],
                __WEBPACK_IMPORTED_MODULE_20__guards_has_yard_privileges_guard__["a" /* HasYardPrivilegesGuard */], __WEBPACK_IMPORTED_MODULE_21__guards_has_sale_privileges_guard__["a" /* HasSalePrivilegesGuard */], __WEBPACK_IMPORTED_MODULE_22__guards_can_view_registered_lots_guard__["a" /* CanViewRegisteredLotsGuard */]],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_4__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "../../../../../src/app/edit-lot/edit-lot.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".form-group {\r\n    margin-left: 21%;\r\n}\r\n\r\n.checkbox {\r\n    margin-left: 47%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/edit-lot/edit-lot.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Modificar lote: \"{{editedLotName}}\"</h2>\r\n</div>\r\n<div [hidden]=\"!foundLot || availableVehicles.length == 0\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <form class=\"form-horizontal\" #lotForm=\"ngForm\" (ngSubmit)=\"editLot()\" name=\"lotForm\" role=\"form\" id=\"lotForm\">\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label col-lg-2\" for=\"name\">Nombre del lote:</label>\r\n            <div class=\"col-lg-5\">\r\n                <input type=\"text\" required class=\"form-control\" pattern=\".*[a-zA-Z].*$\" id=\"name\" [(ngModel)]=\"name\" name=\"name\">\r\n            </div>\r\n        </div><br>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label col-lg-2\" for=\"description\">Descripción:</label>\r\n            <div class=\"col-lg-5\">\r\n                <textarea rows=\"4\" required class=\"form-control\" pattern=\".*[a-zA-Z].*$\" id=\"description\" [(ngModel)]=\"description\" name=\"description\"></textarea>\r\n            </div>\r\n        </div>\r\n        <br>\r\n        <table class='table table-bordered'>\r\n            <thead>\r\n                <tr>\r\n                    <th>Agregar a lote:</th>\r\n                    <th>VIN:</th>\r\n                    <th>Tipo:</th>\r\n                    <th>Marca:</th>\r\n                    <th>Modelo:</th>\r\n                    <th>Color:</th>\r\n                    <th>Año:</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr *ngFor='let aVehicle of availableVehicles'>\r\n                    <td> <input type=\"checkbox\" class=\"checkbox\" name=\"vehicle\" [checked]=\"previousVehicles.indexOf(aVehicle.vin) > -1\" (change)=\"addOrRemoveVIN(aVehicle.vin)\" /></td>\r\n                    <td>{{aVehicle.vin}}</td>\r\n                    <td>{{aVehicle.type}}</td>\r\n                    <td>{{aVehicle.brand}}</td>\r\n                    <td>{{aVehicle.model}}</td>\r\n                    <td>{{aVehicle.color}}</td>\r\n                    <td>{{aVehicle.year}}</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n        <br><br>\r\n        <button type=\"reset\" class=\"btn btn-lg btn-primary changeBtn\">Reestablecer</button>\r\n        <button type=\"submit\" form=\"lotForm\" [disabled]=\"lotForm.invalid\" class=\"btn btn-lg btn-success changeBtn\">Confirmar</button>\r\n    </form>\r\n</div>\r\n<div [hidden]=\"foundLot && availableVehicles.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/edit-lot/edit-lot.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return EditLotComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_lot_service__ = __webpack_require__("../../../../../src/app/services/lot.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__entities_lot__ = __webpack_require__("../../../../../src/app/entities/lot.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var EditLotComponent = (function () {
    function EditLotComponent(_currentRoute, _vehicleService, _lotService) {
        this._currentRoute = _currentRoute;
        this._vehicleService = _vehicleService;
        this._lotService = _lotService;
        this.foundLot = false;
        this.editedLotName = this._currentRoute.snapshot.params['lotName'];
        this.vehicleVINs = [];
        this.availableVehicles = [];
    }
    EditLotComponent.prototype.addOrRemoveVIN = function (someVIN) {
        var index = this.vehicleVINs.indexOf(someVIN, 0);
        if (index > -1) {
            this.vehicleVINs.splice(index, 1);
        }
        else {
            this.vehicleVINs.push(someVIN);
        }
    };
    EditLotComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._lotService.getLotWithName(this.editedLotName)
            .subscribe(function (obtainedLot) { return _this.setPreviousData(obtainedLot); });
    };
    EditLotComponent.prototype.setPreviousData = function (editedLot) {
        var _this = this;
        this.foundLot = true;
        this.name = editedLot.name;
        this.description = editedLot.description;
        this.previousVehicles = editedLot.vehicleVINs;
        this._vehicleService.getVehicles()
            .subscribe(function (vehiclesObtained) { return _this.initializeVehicles(vehiclesObtained); });
    };
    EditLotComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage === __WEBPACK_IMPORTED_MODULE_5__environments_environment__["a" /* environment */].PORT_STAGE &&
                (!vehicle.wasLotted || this.previousVehicles.indexOf(vehicle.vin) > -1)) {
                this.availableVehicles.push(vehicle);
            }
        }
    };
    EditLotComponent.prototype.editLot = function () {
        if (this.vehicleVINs.length > 0) {
            var lotData = new __WEBPACK_IMPORTED_MODULE_4__entities_lot__["a" /* Lot */](this.name, this.description, this.vehicleVINs);
            this._lotService.editLotWithName(this.editedLotName, lotData);
        }
        else {
            alert("Es necesario seleccionar al menos un vehículo para el lote.");
        }
    };
    EditLotComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'edit-lot-component',
            template: __webpack_require__("../../../../../src/app/edit-lot/edit-lot.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/edit-lot/edit-lot.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_router__["a" /* ActivatedRoute */],
            __WEBPACK_IMPORTED_MODULE_3__services_vehicle_service__["a" /* VehicleService */],
            __WEBPACK_IMPORTED_MODULE_1__services_lot_service__["a" /* LotService */]])
    ], EditLotComponent);
    return EditLotComponent;
}());



/***/ }),

/***/ "../../../../../src/app/entities/damage.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Damage; });
var Damage = (function () {
    function Damage(description, images) {
        if (description === void 0) { description = ""; }
        if (images === void 0) { images = []; }
        this.description = description;
        this.images = images;
    }
    return Damage;
}());



/***/ }),

/***/ "../../../../../src/app/entities/inspection.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Inspection; });
var Inspection = (function () {
    function Inspection(locationName, dateTime, damages) {
        if (locationName === void 0) { locationName = ""; }
        if (dateTime === void 0) { dateTime = ""; }
        if (damages === void 0) { damages = []; }
        this.locationName = locationName;
        this.dateTime = dateTime;
        this.damages = damages;
    }
    return Inspection;
}());



/***/ }),

/***/ "../../../../../src/app/entities/lot.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Lot; });
var Lot = (function () {
    function Lot(name, description, vehicleVINs) {
        if (name === void 0) { name = ""; }
        if (description === void 0) { description = ""; }
        if (vehicleVINs === void 0) { vehicleVINs = []; }
        this.name = name;
        this.description = description;
        this.vehicleVINs = vehicleVINs;
    }
    return Lot;
}());



/***/ }),

/***/ "../../../../../src/app/entities/sale.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Sale; });
var Sale = (function () {
    function Sale(customerName, customerPhoneNumber, sellingPrice) {
        if (customerName === void 0) { customerName = ""; }
        if (customerPhoneNumber === void 0) { customerPhoneNumber = ""; }
        if (sellingPrice === void 0) { sellingPrice = 0; }
        this.buyerName = customerName;
        this.buyerPhoneNumber = customerPhoneNumber;
        this.sellingPrice = sellingPrice;
        this.dateTime = new Date();
    }
    return Sale;
}());



/***/ }),

/***/ "../../../../../src/app/entities/transport.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Transport; });
var Transport = (function () {
    function Transport(id, transporterUsername, startDateTime, transportedLotsNames) {
        if (id === void 0) { id = 0; }
        if (transporterUsername === void 0) { transporterUsername = ""; }
        if (startDateTime === void 0) { startDateTime = ""; }
        if (transportedLotsNames === void 0) { transportedLotsNames = []; }
        this.id = id;
        this.transporterUsername = transporterUsername;
        this.startDateTime = startDateTime;
        this.transportedLotsNames = transportedLotsNames;
    }
    return Transport;
}());



/***/ }),

/***/ "../../../../../src/app/guards/can-view-registered-lots-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CanViewRegisteredLotsGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__ = __webpack_require__("../../../../../src/environments/environment.prod.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var CanViewRegisteredLotsGuard = (function () {
    function CanViewRegisteredLotsGuard(_router) {
        this._router = _router;
    }
    CanViewRegisteredLotsGuard.prototype.canActivate = function (route) {
        var notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        }
        else {
            return this.validateUserHasPrivileges();
        }
    };
    CanViewRegisteredLotsGuard.prototype.validateUserHasPrivileges = function () {
        var userRole = sessionStorage.getItem("role");
        var isInvalidUserRole = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].ADMINISTRATOR_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].PORT_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].TRANSPORTER_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        }
        else {
            return true;
        }
    };
    CanViewRegisteredLotsGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], CanViewRegisteredLotsGuard);
    return CanViewRegisteredLotsGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/has-port-privileges-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HasPortPrivilegesGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HasPortPrivilegesGuard = (function () {
    function HasPortPrivilegesGuard(_router) {
        this._router = _router;
    }
    HasPortPrivilegesGuard.prototype.canActivate = function (route) {
        var notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        }
        else {
            return this.validateUserHasPrivileges();
        }
    };
    HasPortPrivilegesGuard.prototype.validateUserHasPrivileges = function () {
        var userRole = sessionStorage.getItem("role");
        var isInvalidUserRole = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].ADMINISTRATOR_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].PORT_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        }
        else {
            return true;
        }
    };
    HasPortPrivilegesGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], HasPortPrivilegesGuard);
    return HasPortPrivilegesGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/has-sale-privileges-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HasSalePrivilegesGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__ = __webpack_require__("../../../../../src/environments/environment.prod.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HasSalePrivilegesGuard = (function () {
    function HasSalePrivilegesGuard(_router) {
        this._router = _router;
    }
    HasSalePrivilegesGuard.prototype.canActivate = function (route) {
        var notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        }
        else {
            return this.validateUserHasPrivileges();
        }
    };
    HasSalePrivilegesGuard.prototype.validateUserHasPrivileges = function () {
        var userRole = sessionStorage.getItem("role");
        var isInvalidUserRole = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].ADMINISTRATOR_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].SALESMAN_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        }
        else {
            return true;
        }
    };
    HasSalePrivilegesGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], HasSalePrivilegesGuard);
    return HasSalePrivilegesGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/has-transport-privileges-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HasTrasportPrivilegesGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__ = __webpack_require__("../../../../../src/environments/environment.prod.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HasTrasportPrivilegesGuard = (function () {
    function HasTrasportPrivilegesGuard(_router) {
        this._router = _router;
    }
    HasTrasportPrivilegesGuard.prototype.canActivate = function (route) {
        var notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        }
        else {
            return this.validateUserHasPrivileges();
        }
    };
    HasTrasportPrivilegesGuard.prototype.validateUserHasPrivileges = function () {
        var userRole = sessionStorage.getItem("role");
        var isInvalidUserRole = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].ADMINISTRATOR_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].TRANSPORTER_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        }
        else {
            return true;
        }
    };
    HasTrasportPrivilegesGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], HasTrasportPrivilegesGuard);
    return HasTrasportPrivilegesGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/has-yard-privileges-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HasYardPrivilegesGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var HasYardPrivilegesGuard = (function () {
    function HasYardPrivilegesGuard(_router) {
        this._router = _router;
    }
    HasYardPrivilegesGuard.prototype.canActivate = function (route) {
        var notLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("token") == null ||
            sessionStorage.getItem("role") == null;
        if (notLoggedIn) {
            this._router.navigate(['/login']);
            return false;
        }
        else {
            return this.validateUserHasPrivileges();
        }
    };
    HasYardPrivilegesGuard.prototype.validateUserHasPrivileges = function () {
        var userRole = sessionStorage.getItem("role");
        var isInvalidUserRole = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].ADMINISTRATOR_ROLE
            && userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].YARD_ROLE;
        if (isInvalidUserRole) {
            alert("Acceso denegado: son necesarios privilegios superiores.");
            this._router.navigate(['/app']);
            return false;
        }
        else {
            return true;
        }
    };
    HasYardPrivilegesGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], HasYardPrivilegesGuard);
    return HasYardPrivilegesGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/is-logged-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return IsLoggedGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var IsLoggedGuard = (function () {
    function IsLoggedGuard(_router) {
        this._router = _router;
    }
    IsLoggedGuard.prototype.canActivate = function (route) {
        var userIsLoggedIn = sessionStorage.getItem("username") != null &&
            sessionStorage.getItem("role") != null &&
            sessionStorage.getItem("token") != null;
        if (userIsLoggedIn) {
            return true;
        }
        else {
            this._router.navigate(['/login']);
            return false;
        }
    };
    IsLoggedGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], IsLoggedGuard);
    return IsLoggedGuard;
}());



/***/ }),

/***/ "../../../../../src/app/guards/is-not-logged-guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return IsNotLoggedGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var IsNotLoggedGuard = (function () {
    function IsNotLoggedGuard(_router) {
        this._router = _router;
    }
    IsNotLoggedGuard.prototype.canActivate = function (route) {
        var userIsNotLoggedIn = sessionStorage.getItem("username") == null ||
            sessionStorage.getItem("role") == null ||
            sessionStorage.getItem("token") == null;
        if (userIsNotLoggedIn) {
            return true;
        }
        else {
            this._router.navigate(['/app']);
            return false;
        }
    };
    IsNotLoggedGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_router__["b" /* Router */]])
    ], IsNotLoggedGuard);
    return IsNotLoggedGuard;
}());



/***/ }),

/***/ "../../../../../src/app/login/login.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "div#main {\r\n    display: table;\r\n    width: 100%;\r\n    height: 100%;\r\n    min-height: 100%;\r\n}\r\n\r\nbody {\r\n    color: #fff;\r\n    text-align: center;\r\n    text-shadow: 0 1px 3px rgba(0, 0, 0, .5);\r\n}\r\n\r\ndiv#innerContainer {\r\n    background-color: darkgray;\r\n    color: #333;\r\n    display: table-cell;\r\n    text-align: center;\r\n    vertical-align: center;\r\n    background-size: cover;\r\n}\r\n\r\nh1#mainTitle {\r\n    font-size: 550%;\r\n    margin-top: 5%;\r\n    margin-bottom: 1.5%;\r\n}\r\n\r\nh3#subtitle {\r\n    font-style: italic;\r\n}\r\n\r\ndiv#formContainer {\r\n    margin-top: 5%;\r\n}\r\n\r\nh3#loginFormTitle {\r\n    margin-bottom: 0px;\r\n}\r\n\r\nform#loginForm {\r\n    max-width: 330px;\r\n    padding: 15px;\r\n    margin: 0 auto;\r\n}\r\n\r\nform#loginForm .form-control {\r\n    position: relative;\r\n    height: auto;\r\n    box-sizing: border-box;\r\n    padding: 10px;\r\n    font-size: 16px;\r\n}\r\n\r\nform#loginForm .form-control:focus {\r\n    z-index: 2;\r\n}\r\n\r\ninput#txtUsername {\r\n    margin-bottom: -1px;\r\n    margin-bottom: 5px;\r\n}\r\n\r\ninput#txtPassword {\r\n    margin-bottom: 10px;\r\n}\r\n\r\nspan#information {\r\n    position: fixed;\r\n    bottom: 0px;\r\n    right: 10px;\r\n    text-align: right;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/login/login.component.html":
/***/ (function(module, exports) {

module.exports = "<div id=\"main\">\r\n    <div id=\"innerContainer\">\r\n        <div class=\"alert alert-danger\" id=\"errorAlert\" [hidden]=\"!errorOcurred\">\r\n            <span class=\"glyphicon glyphicon-exclamation-sign\" aria-hidden=\"true\"></span>\r\n            <strong>Error: </strong>\r\n            <span id=\"errorMessage\">{{errorMessage}}</span>\r\n        </div>\r\n        <div class=\"alert alert-success\" [hidden]=\"!success\" id=\"successAlert\">\r\n            <span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>\r\n            <strong>Éxito: </strong> Ingreso de sesión correcto.\r\n        </div>\r\n        <h1 id=\"mainTitle\">Vehicle Tracking System:</h1>\r\n        <h3 id=\"subtitle\">Sistema de gestión del proceso de venta de vehículos.</h3>\r\n        <div class=\"container\" id=\"formContainer\">\r\n            <h3 id=\"loginFormTitle\">Inicio de sesión:</h3>\r\n            <form #loginForm=\"ngForm\" (ngSubmit)=\"attemptToLoginUser()\" pattern=\"\\^[ 0-9A-Z]+$\\i\" id=\"loginForm\" accept-charset=\"UTF-8\" role=\"form\">\r\n                <label for=\"txtUsername\" class=\"sr-only\">Usuario</label>\r\n                <input type=\"text\" id=\"txtUsername\" name=\"username\" class=\"form-control\" placeholder=\"Usuario\" [(ngModel)]=\"username\" type=\"text\" required autofocus>\r\n                <label for=\"txtPassword\" class=\"sr-only\">Password</label>\r\n                <input type=\"password\" id=\"txtPassword\" name=\"password\" class=\"form-control\" placeholder=\"Contraseña\" [(ngModel)]=\"password\" required>\r\n                <button class=\"btn btn-lg btn-primary btn-block\" [disabled]=\"loginForm.invalid\" id=\"btnSubmit\" type=\"submit\">Entrar</button>\r\n                <br>\r\n            </form>\r\n        </div>\r\n        <span id=\"information\">\r\n            Obligatorio: Diseño de Aplicaciones II.\r\n            <br> Lucía Dabezies, Nº de estudiante: 200604.\r\n            <br> Sebastián Uriarte Güimil, Nº de estudiante: 194973.\r\n            <br> Universidad ORT Uruguay, 2017.\r\n          </span>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/login/login.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__services_login_service__ = __webpack_require__("../../../../../src/app/services/login-service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var LoginComponent = (function () {
    function LoginComponent(_loginService) {
        this._loginService = _loginService;
        this.success = false;
        this.errorOcurred = false;
    }
    LoginComponent.prototype.attemptToLoginUser = function () {
        this._loginService.attemptLoginWithData(this.username, this.password, this);
    };
    LoginComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_1__angular_core__["n" /* Component */])({
            selector: 'login',
            template: __webpack_require__("../../../../../src/app/login/login.component.html"),
            styles: [__webpack_require__("../../../../../src/app/login/login.component.css")],
            providers: [__WEBPACK_IMPORTED_MODULE_0__services_login_service__["a" /* LoginService */]]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__services_login_service__["a" /* LoginService */]])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "../../../../../src/app/lot-list/lot-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Lotes</h2>\r\n</div>\r\n<div [hidden]=\"lots.length == 0\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <table class='table table-bordered'>\r\n        <thead>\r\n            <tr>\r\n                <th></th>\r\n                <th>Nombre:</th>\r\n                <th>Descripción:</th>\r\n                <th>Creador:</th>\r\n                <th>Vehículos:</th>\r\n                <th>Listo para el transporte:</th>\r\n                <th>Transportado:</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor='let aLot of lots'>\r\n                <td>\r\n                    <input name=\"lotSelector\" class=\"lotRadiobutton\" type=\"radio\" (click)=\"setSelectedLot(aLot)\" />\r\n                </td>\r\n                <td>{{aLot.name}}</td>\r\n                <td>{{aLot.description}}</td>\r\n                <td>{{aLot.creatorUsername}}</td>\r\n                <td>{{aLot.vehicleVINs}}</td>\r\n                <td>\r\n                    <span *ngIf=\"aLot.isReadyForTransport\" class=\"glyphicon glyphicon-ok\"></span>\r\n                    <span *ngIf=\"!aLot.isReadyForTransport\" class=\"glyphicon glyphicon-remove\"></span>\r\n                </td>\r\n                <td>\r\n                    <span *ngIf=\"aLot.wasTransported\" class=\"glyphicon glyphicon-ok\"></span>\r\n                    <span *ngIf=\"!aLot.wasTransported\" class=\"glyphicon glyphicon-remove\"></span>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <br><br>\r\n    <button type=\"button\" class=\"btn btn-lg btn-danger changeBtn\" [disabled]=\"selectedLot == null || selectedLot.wasTransported\" (click)='deleteLot()' id=\"deleteLotBtn\">Eliminar</button>\r\n    <button type=\"button\" class=\"btn btn-lg btn-primary changeBtn\" [disabled]=\"selectedLot == null || selectedLot.wasTransported\" (click)='editLot()' id=\"editLotBtn\">Editar</button>\r\n</div>\r\n<div [hidden]=\"lots.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/lot-list/lot-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LotListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_lot_service__ = __webpack_require__("../../../../../src/app/services/lot.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var LotListComponent = (function () {
    function LotListComponent(_lotService, _router) {
        this._lotService = _lotService;
        this._router = _router;
        this.lots = [];
        this.selectedLot = null;
    }
    LotListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._lotService.getLots()
            .subscribe(function (lotsObtained) { return _this.lots = lotsObtained; });
    };
    LotListComponent.prototype.setSelectedLot = function (someLot) {
        this.selectedLot = someLot;
    };
    LotListComponent.prototype.deleteLot = function () {
        var result = confirm("¿Está seguro que desea eliminar al lote seleccionado?");
        if (result) {
            this._lotService.deleteLotWithName(this.selectedLot.name);
        }
    };
    LotListComponent.prototype.editLot = function () {
        this._router.navigate(['/app/editLot', this.selectedLot.name]);
    };
    LotListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-lot-list',
            template: __webpack_require__("../../../../../src/app/lot-list/lot-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_lot_service__["a" /* LotService */],
            __WEBPACK_IMPORTED_MODULE_2__angular_router__["b" /* Router */]])
    ], LotListComponent);
    return LotListComponent;
}());



/***/ }),

/***/ "../../../../../src/app/options-menu/options-menu.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "body {\r\n    margin-top: 100px;\r\n    background-color: #222;\r\n}\r\n\r\n@media(min-width:768px) {\r\n    body {\r\n        margin-top: 50px;\r\n    }\r\n}\r\n\r\n#wrapper {\r\n    padding-left: 0;\r\n}\r\n\r\n#page-wrapper {\r\n    width: 100%;\r\n    padding: 0;\r\n    background-color: #fff;\r\n}\r\n\r\n.huge {\r\n    font-size: 50px;\r\n    line-height: normal;\r\n}\r\n\r\n@media(min-width:768px) {\r\n    #wrapper {\r\n        padding-left: 225px;\r\n    }\r\n    #page-wrapper {\r\n        padding: 10px;\r\n    }\r\n}\r\n\r\n@media(min-width:768px) {\r\n    .side-nav {\r\n        position: fixed;\r\n        top: 51px;\r\n        left: 225px;\r\n        width: 225px;\r\n        margin-left: -225px;\r\n        border: none;\r\n        border-radius: 0;\r\n        overflow-y: auto;\r\n        background-color: #222;\r\n        bottom: 0;\r\n        overflow-x: hidden;\r\n        padding-bottom: 40px;\r\n    }\r\n    .side-nav>li>a {\r\n        width: 225px;\r\n    }\r\n    .side-nav li a:hover,\r\n    .side-nav li a:focus {\r\n        outline: none;\r\n        background-color: #000;\r\n    }\r\n}\r\n\r\n.side-nav>li>ul {\r\n    padding: 0;\r\n}\r\n\r\n.side-nav>li>ul>li>a {\r\n    display: block;\r\n    padding: 10px 15px 10px 38px;\r\n    text-decoration: none;\r\n    color: #999;\r\n}\r\n\r\n.side-nav>li>ul>li>a:hover {\r\n    color: #fff;\r\n}\r\n\r\na.secondLevel {\r\n    font-size: 14px;\r\n}\r\n\r\ndiv#contents {\r\n    background-color: darkgray;\r\n}\r\n\r\na#optionsTitle {\r\n    font-weight: bold;\r\n    font-size: 28px;\r\n}\r\n\r\nli#logoutBtnContainer {\r\n    width: 100%;\r\n}\r\n\r\nbutton#logoutBtn {\r\n    width: 100%;\r\n    color: black;\r\n}\r\n\r\n.hidden {\r\n    display: none;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/options-menu/options-menu.component.html":
/***/ (function(module, exports) {

module.exports = "<div id=\"wrapper\">\r\n    <nav class=\"navbar navbar-inverse navbar-fixed-top\" role=\"navigation\">\r\n        <div class=\"navbar-header\">\r\n            <button type=\"button\" class=\"navbar-toggle\" data-toggle=\"collapse\" data-target=\".navbar-ex1-collapse\">\r\n                        <span class=\"sr-only\">Abrir menú de navegación</span>\r\n                        <span class=\"icon-bar\"></span>\r\n                        <span class=\"icon-bar\"></span>\r\n                        <span class=\"icon-bar\"></span>\r\n                    </button>\r\n            <a class=\"navbar-brand\" href=\"index.html\">Vehicle Tracking System</a>\r\n        </div>\r\n        <div class=\"collapse navbar-collapse navbar-ex1-collapse\">\r\n            <ul class=\"nav navbar-nav side-nav\">\r\n                <br><br><br>\r\n                <div class=\"brand-name-wrapper\">\r\n                    <a class=\"navbar-brand\" id=\"optionsTitle\">Opciones:</a>\r\n                </div>\r\n                <br><br><br><br>\r\n                <li>\r\n                    <a routerLink=\"/app/vehicles\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Ver vehículos registrados\r\n                    </a>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoPortPrivileges\">\r\n                    <a routerLink=\"/app/registerPortInspection\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Registrar inspección de puerto\r\n                    </a>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoLotVisualizationPrivileges\" id=\"dropdown\">\r\n                    <a data-toggle=\"collapse\" href=\"#dropdown-lots\" class=\"collapsed\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Lotes\r\n                        <span class=\"caret\"></span>\r\n                    </a>\r\n                    <div id=\"dropdown-lots\" class=\"panel-collapse collapse\">\r\n                        <div class=\"panel-body\">\r\n                            <ul class=\"nav navbar-nav\">\r\n                                <li [class.hidden]=\"userHasNoLotVisualizationPrivileges\">\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/lots\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Ver lotes\r\n                                    </a>\r\n                                </li>\r\n                                <li [class.hidden]=\"userHasNoPortPrivileges\">\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/registerLot\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Registrar nuevo lote\r\n                                    </a>\r\n                                </li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoTransportPrivileges\" id=\"dropdown\">\r\n                    <a data-toggle=\"collapse\" href=\"#dropdown-transports\" class=\"collapsed\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Transportes\r\n                        <span class=\"caret\"></span>\r\n                    </a>\r\n                    <div id=\"dropdown-transports\" class=\"panel-collapse collapse\">\r\n                        <div class=\"panel-body\">\r\n                            <ul class=\"nav navbar-nav\">\r\n                                <li>\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/transports\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Ver transportes\r\n                                    </a>\r\n                                </li>\r\n                                <li>\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/registerTransport\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Registrar transporte\r\n                                    </a>\r\n                                </li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoYardPrivileges\">\r\n                    <a routerLink=\"/app/registerYardInspection\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Registrar inspección de patio\r\n                    </a>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoYardPrivileges\">\r\n                    <a routerLink=\"/app/registerMovement\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Registrar movimiento\r\n                    </a>\r\n                </li>\r\n                <li [class.hidden]=\"userHasNoSalePrivileges\" id=\"dropdown\">\r\n                    <a data-toggle=\"collapse\" href=\"#dropdown-sales\" class=\"collapsed\">\r\n                        <span class=\"glyphicon glyphicon-triangle-right\"></span> Ventas\r\n                        <span class=\"caret\"></span>\r\n                    </a>\r\n                    <div id=\"dropdown-sales\" class=\"panel-collapse collapse\">\r\n                        <div class=\"panel-body\">\r\n                            <ul class=\"nav navbar-nav\">\r\n                                <li>\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/sales\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Ver ventas registradas\r\n                                    </a>\r\n                                </li>\r\n                                <li>\r\n                                    <a class=\"secondLevel\" routerLink=\"/app/registerSale\">\r\n                                        <span class=\"glyphicon glyphicon-menu-right\"></span> Registrar nueva venta\r\n                                    </a>\r\n                                </li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n                <li id=\"logoutBtnContainer\">\r\n                    <br><br>\r\n                    <button class=\"btn btn-lg btn-primary btn-block\" (click)=\"processLogout()\" id=\"logoutBtn\">Cerrar sesión</button>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n    <div class=\"container-fluid\" id=\"contents\">\r\n        <div class=\"side-body\">\r\n            <router-outlet></router-outlet>\r\n        </div>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/options-menu/options-menu.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return OptionsMenuComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__ = __webpack_require__("../../../../../src/environments/environment.prod.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var OptionsMenuComponent = (function () {
    function OptionsMenuComponent(_router) {
        this._router = _router;
    }
    OptionsMenuComponent.prototype.ngOnInit = function () {
        var userRole = sessionStorage.getItem("role");
        var isNotAdministrator = userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].ADMINISTRATOR_ROLE;
        this.userHasNoPortPrivileges = isNotAdministrator &&
            userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].PORT_ROLE;
        this.userHasNoTransportPrivileges = isNotAdministrator &&
            userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].TRANSPORTER_ROLE;
        this.userHasNoYardPrivileges = isNotAdministrator &&
            userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].YARD_ROLE;
        this.userHasNoSalePrivileges = isNotAdministrator &&
            userRole !== __WEBPACK_IMPORTED_MODULE_2__environments_environment_prod__["a" /* environment */].SALESMAN_ROLE;
        this.userHasNoLotVisualizationPrivileges = this.userHasNoPortPrivileges
            && this.userHasNoTransportPrivileges;
    };
    OptionsMenuComponent.prototype.processLogout = function () {
        sessionStorage.clear();
        this._router.navigate(["/login"]);
    };
    OptionsMenuComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'options-menu',
            template: __webpack_require__("../../../../../src/app/options-menu/options-menu.component.html"),
            styles: [__webpack_require__("../../../../../src/app/options-menu/options-menu.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */]])
    ], OptionsMenuComponent);
    return OptionsMenuComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-lot/lot.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".form-group {\r\n    margin-left: 21%;\r\n}\r\n\r\n.checkbox {\r\n    margin-left: 47%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-lot/lot.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registro de Lote</h2>\r\n</div>\r\n<div [hidden]=\"availableVehicles.length == 0\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <form class=\"form-horizontal\" #lotForm=\"ngForm\" (ngSubmit)=\"registerNewLot()\" name=\"lotForm\" role=\"form\" id=\"lotForm\">\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label col-lg-2\" for=\"name\">Nombre del lote:</label>\r\n            <div class=\"col-lg-5\">\r\n                <input type=\"text\" required class=\"form-control\" pattern=\".*[a-zA-Z].*$\" id=\"name\" [(ngModel)]=\"name\" name=\"name\">\r\n            </div>\r\n        </div><br>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label col-lg-2\" for=\"description\">Descripción:</label>\r\n            <div class=\"col-lg-5\">\r\n                <textarea rows=\"4\" required class=\"form-control\" pattern=\".*[a-zA-Z].*$\" id=\"description\" [(ngModel)]=\"description\" name=\"description\"></textarea>\r\n            </div>\r\n        </div>\r\n        <br>\r\n        <table class='table table-bordered'>\r\n            <thead>\r\n                <tr>\r\n                    <th>Agregar a lote:</th>\r\n                    <th>VIN:</th>\r\n                    <th>Tipo:</th>\r\n                    <th>Marca:</th>\r\n                    <th>Modelo:</th>\r\n                    <th>Color:</th>\r\n                    <th>Año:</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <tr *ngFor='let aVehicle of availableVehicles'>\r\n                    <td> <input type=\"checkbox\" class=\"checkbox\" name=\"vehicle\" (change)=\"addOrRemoveVIN(aVehicle.vin)\" /></td>\r\n                    <td>{{aVehicle.vin}}</td>\r\n                    <td>{{aVehicle.type}}</td>\r\n                    <td>{{aVehicle.brand}}</td>\r\n                    <td>{{aVehicle.model}}</td>\r\n                    <td>{{aVehicle.color}}</td>\r\n                    <td>{{aVehicle.year}}</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n        <br><br>\r\n        <button type=\"reset\" class=\"btn btn-lg btn-primary changeBtn\">Reestablecer</button>\r\n        <button type=\"submit\" form=\"lotForm\" [disabled]=\"lotForm.invalid\" class=\"btn btn-lg btn-success changeBtn\">Confirmar</button>\r\n    </form>\r\n</div>\r\n<div [hidden]=\"availableVehicles.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar: no existen vehículos válidos.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-lot/lot.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LotComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_lot_service__ = __webpack_require__("../../../../../src/app/services/lot.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__entities_lot__ = __webpack_require__("../../../../../src/app/entities/lot.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var LotComponent = (function () {
    function LotComponent(_vehicleService, _lotService) {
        this._vehicleService = _vehicleService;
        this._lotService = _lotService;
        this.vehicleVINs = [];
        this.availableVehicles = [];
    }
    LotComponent.prototype.addOrRemoveVIN = function (someVIN) {
        var index = this.vehicleVINs.indexOf(someVIN, 0);
        if (index > -1) {
            this.vehicleVINs.splice(index, 1);
        }
        else {
            this.vehicleVINs.push(someVIN);
        }
    };
    LotComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getVehicles()
            .subscribe(function (vehiclesObtained) { return _this.initializeVehicles(vehiclesObtained); });
    };
    LotComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage === __WEBPACK_IMPORTED_MODULE_4__environments_environment__["a" /* environment */].PORT_STAGE &&
                !vehicle.wasLotted) {
                this.availableVehicles.push(vehicle);
            }
        }
    };
    LotComponent.prototype.registerNewLot = function () {
        if (this.vehicleVINs.length > 0) {
            var lotToAdd = new __WEBPACK_IMPORTED_MODULE_3__entities_lot__["a" /* Lot */](this.name, this.description, this.vehicleVINs);
            this._lotService.registerNewLot(lotToAdd);
        }
        else {
            alert("Es necesario seleccionar al menos un vehículo para el lote.");
        }
    };
    LotComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'lot-component',
            template: __webpack_require__("../../../../../src/app/register-lot/lot.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/register-lot/lot.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__services_vehicle_service__["a" /* VehicleService */],
            __WEBPACK_IMPORTED_MODULE_1__services_lot_service__["a" /* LotService */]])
    ], LotComponent);
    return LotComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-movement/movement.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "form#movementForm {\r\n    margin-top: 5%;\r\n    margin-left: 9%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-movement/movement.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registrar movimiento</h2>\r\n</div><br><br>\r\n<div class=\"container\">\r\n    <div class=\"row\" [hidden]=\"subzones.length == 0 || vehicles.length == 0\" id=\"contentsContainer\">\r\n        <form class=\"form-horizontal col-lg-10\" (ngSubmit)=\"registerMovement()\" #movementForm=\"ngForm\" name=\"movementForm\" role=\"form\" id=\"movementForm\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"vehicleSelect\">Vehículo:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <select class=\"form-control\" [(ngModel)]=\"selectedVehicleVIN\" required name=\"vehicleSelect\" id=\"vehicleSelect\">\r\n                        <option *ngFor = 'let aVehicle of vehicles' [ngValue]=\"aVehicle.vin\">{{aVehicle.vin}}</option>\r\n                    </select>\r\n                </div>\r\n            </div>\r\n            <br><br>\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"arrivalSelect\">Subzona de llegada:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <select class=\"form-control\" [(ngModel)]=\"arrivalId\" required name=\"arrivalSelect\" id=\"arrivalSelect\">\r\n                        <option *ngFor = 'let aSubzone of subzones' [ngValue]=\"aSubzone.id\">{{aSubzone.containerName}}/{{aSubzone.name}}</option>\r\n                    </select>\r\n                </div>\r\n            </div>\r\n            <br><br><br><br><br><br>\r\n            <button type=\"submit\" class=\"btn btn-lg btn-success changeBtn\" [disabled]=\"movementForm.invalid\" id=\"registerMovementBtn\">Registrar movimiento</button>\r\n        </form>\r\n    </div>\r\n</div>\r\n<div [hidden]=\"subzones.length > 0 && vehicles.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>No es posible registrar movimientos con los datos ingresados en el sistema.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-movement/movement.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MovementComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_subzone_service__ = __webpack_require__("../../../../../src/app/services/subzone.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__services_movement_service__ = __webpack_require__("../../../../../src/app/services/movement.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var MovementComponent = (function () {
    function MovementComponent(_subzoneService, _vehicleService, _movementService) {
        this._subzoneService = _subzoneService;
        this._vehicleService = _vehicleService;
        this._movementService = _movementService;
        this.subzones = [];
        this.vehicles = [];
    }
    MovementComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._subzoneService.getSubzones()
            .subscribe(function (subzonesObtained) { return _this.subzones = subzonesObtained; });
        this.subzones.map(function (itemInArray) { return itemInArray.name; });
        this._vehicleService.getVehicles()
            .subscribe(function (obtainedVehicles) { return _this.initializeVehicles(obtainedVehicles); });
        this.vehicles.map(function (itemInArray) { return itemInArray.vin; });
    };
    MovementComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage.indexOf(__WEBPACK_IMPORTED_MODULE_4__environments_environment__["a" /* environment */].YARD_STAGE_PREFIX)
                !== -1) {
                this.vehicles.push(vehicle);
            }
        }
    };
    MovementComponent.prototype.registerMovement = function () {
        this._movementService.registerNewMovement(this.arrivalId, this.selectedVehicleVIN);
    };
    MovementComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-movement',
            template: __webpack_require__("../../../../../src/app/register-movement/movement.component.html"),
            styles: [__webpack_require__("../../../../../src/app/register-movement/movement.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_subzone_service__["a" /* SubzoneService */], __WEBPACK_IMPORTED_MODULE_2__services_vehicle_service__["a" /* VehicleService */],
            __WEBPACK_IMPORTED_MODULE_3__services_movement_service__["a" /* MovementService */]])
    ], MovementComponent);
    return MovementComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-port-inspection/port-inspection.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "form#inspectionForm {\r\n    margin-top: 3%;\r\n    margin-left: 12%;\r\n}\r\n\r\nbutton#registerInspection {\r\n    margin-left: 15px;\r\n}\r\n\r\ndiv#damagesContainer {\r\n    background-color: white;\r\n    min-height: 150px;\r\n    text-align: center;\r\n}\r\n\r\ninput#descriptionTxt {\r\n    min-width: 350px;\r\n}\r\n\r\ninput.damageInput {\r\n    margin-right: 20px;\r\n}\r\n\r\nh3#addDamage {\r\n    font-weight: bold;\r\n}\r\n\r\nth#descriptionColumn {\r\n    min-width: 300px;\r\n    max-width: 475px;\r\n}\r\n\r\ntd.descriptionCell {\r\n    max-width: 475px;\r\n    overflow-wrap: break-word;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-port-inspection/port-inspection.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registro de Inspección de Puerto</h2>\r\n</div>\r\n<div class=\"container\">\r\n    <div [hidden]=\"vehicles.length == 0 || portNames.length == 0\" id=\"contentsContainer\">\r\n        <div class=\"row\">\r\n            <form class=\"form-horizontal col-lg-10\" (ngSubmit)=\"registerPortInspection()\" #inspectionForm=\"ngForm\" name=\"inspectionForm\" role=\"form\" id=\"inspectionForm\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"vehicleSelect\">Vehículo:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <select class=\"form-control\" [(ngModel)]=\"selectedVehicle\" required name=\"vehicleSelect\" id=\"vehicleSelect\">\r\n                          <option *ngFor='let aVehicle of vehicles' [ngValue]=\"aVehicle.vin\">{{aVehicle.vin}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"locationSelect\">Ubicación:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <select class=\"form-control\" [(ngModel)]=\"selectedLocation\" required name=\"locationSelect\" id=\"locationSelect\">\r\n                          <option *ngFor='let aName of portNames' [ngValue]=\"aName\">{{aName}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div><br>\r\n        <h3 id=\"addDamage\">Agregar daño:</h3><br>\r\n        <form class=\"form-inline\" #damageForm=\"ngForm\" (ngSubmit)=\"attemptToAddDamage()\" name=\"damageForm\">\r\n            <div class=\"form-group\">\r\n                <label for=\"descriptionTxt\">Descripción:</label>\r\n                <input type=\"text\" required class=\"form-control damageInput\" pattern=\".*[a-zA-Z].*$\" id=\"descriptionTxt\" [(ngModel)]=\"damageDescription\" name=\"description\">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"imageFileChooser\">Imágenes:</label>\r\n                <input type=\"file\" name=\"pic\" required accept=\"image/*\" multiple (change)=\"getFiles($event)\" class=\"form-control damageInput\" id=\"imageFileChooser\">\r\n            </div>\r\n            <button type=\"submit\" [disabled]=\"damageForm.invalid\" class=\"btn btn-default btn-danger\" name=\"addDamage\" id=\"addDamage\">Agregar daño</button>\r\n            <div class=\"row\">\r\n                <br>\r\n            </div>\r\n            <div class=\"row\" id=\"damagesContainer\">\r\n                <table [hidden]=\"!damages.length\" class='table table-bordered'>\r\n                    <thead>\r\n                        <tr>\r\n                            <th id=\"descriptionColumn\">Descripción:</th>\r\n                            <th>Imágenes:</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr *ngFor='let damage of damages'>\r\n                            <td class=\"descriptionCell\">{{damage.description}}</td>\r\n                            <td>\r\n                                <img class=\"img-thumbnail\" *ngFor='let image of damage.images' [src]=\"_DomSanitizer.bypassSecurityTrustUrl(image)\" width=\"250\" height=\"auto\" alt=\"Evidencia de daño.\">\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n                <span [hidden]=\"damages.length\">\r\n              <br><br>\r\n              <h4>Inspección sin daños.</h4>\r\n            </span>\r\n            </div><br>\r\n            <button type=\"reset\" class=\"btn btn-lg btn-primary changeBtn\" (click)='clearDamages()'>Reestablecer</button>\r\n            <button type=\"submit\" form=\"inspectionForm\" [disabled]=\"inspectionForm.invalid\" class=\"btn btn-lg btn-success changeBtn\" id=\"registerInspection\">Confirmar</button>\r\n        </form>\r\n    </div>\r\n    <div [hidden]=\"vehicles.length > 0 && portNames.length > 0\" id=\"noContentsContainer\">\r\n        <br><br><br><br><br>\r\n        <h3>No existen vehículos inspeccionables.</h3>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-port-inspection/port-inspection.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PortInspectionComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_location_service__ = __webpack_require__("../../../../../src/app/services/location.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__entities_damage__ = __webpack_require__("../../../../../src/app/entities/damage.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__entities_inspection__ = __webpack_require__("../../../../../src/app/entities/inspection.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__ = __webpack_require__("../../../../../src/app/services/inspection.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var PortInspectionComponent = (function () {
    function PortInspectionComponent(_DomSanitizer, _inspectionService, _vehicleService, _locationService) {
        this._DomSanitizer = _DomSanitizer;
        this._inspectionService = _inspectionService;
        this._vehicleService = _vehicleService;
        this._locationService = _locationService;
        this.vehicles = [];
        this.portNames = [];
        this.damages = [];
    }
    PortInspectionComponent.prototype.getFiles = function (event) {
        this.imageFiles = event.target.files;
    };
    PortInspectionComponent.prototype.attemptToAddDamage = function () {
        if (this.imageFiles.length > 0) {
            var images = this.getImageStrings();
            this.damages.push(new __WEBPACK_IMPORTED_MODULE_3__entities_damage__["a" /* Damage */](this.damageDescription, images));
            alert("Daño agregado exitosamente.");
        }
        else {
            alert("Error: es necesario aportar evidencia fotográfica para"
                + " poder registrar un daño.");
        }
    };
    PortInspectionComponent.prototype.getImageStrings = function () {
        var stringifiedImages = [];
        for (var i = 0; i < this.imageFiles.length; i++) {
            var file = this.imageFiles[i];
            if (!file.type.match('image.*')) {
                throw "Sólo se aceptan imágenes para este campo.";
            }
            this.getImageData(file, stringifiedImages);
        }
        return stringifiedImages;
    };
    PortInspectionComponent.prototype.getImageData = function (file, stringifiedImages) {
        var reader = new FileReader();
        reader.onload = function (e) {
            stringifiedImages.push(reader.result);
        };
        reader.readAsDataURL(file);
    };
    PortInspectionComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getVehicles()
            .subscribe(function (obtainedVehicles) { return _this.initializeVehicles(obtainedVehicles); });
        this._locationService.getPorts()
            .subscribe(function (portsObtained) { return _this.portNames = portsObtained; });
    };
    PortInspectionComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage === __WEBPACK_IMPORTED_MODULE_7__environments_environment__["a" /* environment */].PORT_STAGE
                && vehicle.portInspectionId == null) {
                this.vehicles.push(vehicle);
            }
        }
    };
    PortInspectionComponent.prototype.clearDamages = function () {
        this.damages = [];
    };
    PortInspectionComponent.prototype.registerPortInspection = function () {
        var inspectionToRegister = new __WEBPACK_IMPORTED_MODULE_5__entities_inspection__["a" /* Inspection */](this.selectedLocation, new Date().toUTCString(), this.damages);
        this._inspectionService.registerPortInspection(this.selectedVehicle, inspectionToRegister);
    };
    PortInspectionComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-port-inspection',
            template: __webpack_require__("../../../../../src/app/register-port-inspection/port-inspection.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/register-port-inspection/port-inspection.component.css")],
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_4__angular_platform_browser__["b" /* DomSanitizer */], __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__["a" /* InspectionService */],
            __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__["a" /* VehicleService */], __WEBPACK_IMPORTED_MODULE_2__services_location_service__["a" /* LocationService */]])
    ], PortInspectionComponent);
    return PortInspectionComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-sale/sale.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "form#saleForm {\r\n    margin-top: 3%;\r\n    margin-left: 6%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-sale/sale.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registrar venta</h2>\r\n</div><br><br>\r\n<div class=\"container\">\r\n    <div class=\"row\" [hidden]=\"vehicles.length == 0\" id=\"contentsContainer\">\r\n        <br>\r\n        <form class=\"form-horizontal col-lg-10\" (ngSubmit)=\"registerSale()\" #saleForm=\"ngForm\" name=\"saleForm\" role=\"form\" id=\"saleForm\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"vehicleSelect\">Vehículo:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <select class=\"form-control\" [(ngModel)]=\"selectedVehicleVIN\" required name=\"vehicleSelect\" id=\"vehicleSelect\">\r\n                    <option *ngFor = 'let aVehicle of vehicles' [ngValue]=\"aVehicle.vin\">{{aVehicle.vin}}</option>\r\n                </select>\r\n                </div>\r\n            </div><br>\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"buyerName\">Nombre del comprador:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <input type=\"text\" required class=\"form-control\" pattern=\".*[a-zA-Z].*$\" id=\"buyerName\" [(ngModel)]=\"buyerName\" name=\"buyerName\">\r\n                </div>\r\n            </div><br>\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"buyerPhoneNumber\">Teléfono del comprador:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <input type=\"text\" required class=\"form-control\" pattern=\"^(?!00)[0-9]{8,9}$\" id=\"buyerPhoneNumber\" [(ngModel)]=\"buyerPhoneNumber\" name=\"buyerPhoneNumber\">\r\n                </div>\r\n            </div><br>\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-lg-3\" for=\"sellingPrice\">Precio de venta:</label>\r\n                <div class=\"col-lg-7\">\r\n                    <input type=\"number\" min=\"1\" max=\"2147483647\" required class=\"form-control\" id=\"sellingPrice\" [(ngModel)]=\"sellingPrice\" name=\"sellingPrice\">\r\n                </div>\r\n            </div>\r\n            <br><br><br>\r\n        </form>\r\n        <button type=\"reset\" form=\"saleForm\" class=\"btn btn-lg btn-primary changeBtn\">Reestablecer</button>\r\n        <button type=\"submit\" form=\"saleForm\" class=\"btn btn-lg btn-success changeBtn\" id=\"registerSaleBtn\">Registrar venta</button>\r\n    </div>\r\n</div>\r\n<div [hidden]=\"vehicles.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>No existen vehículos prontos para ser vendidos.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-sale/sale.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SaleComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_saleService__ = __webpack_require__("../../../../../src/app/services/saleService.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__entities_sale__ = __webpack_require__("../../../../../src/app/entities/sale.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var SaleComponent = (function () {
    function SaleComponent(_vehicleService, _saleService) {
        this._vehicleService = _vehicleService;
        this._saleService = _saleService;
        this.vehicles = [];
    }
    SaleComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getVehicles()
            .subscribe(function (vehiclesObtained) { return _this.initializeVehicles(vehiclesObtained); });
    };
    SaleComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage === __WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].READY_FOR_SALE_STAGE) {
                this.vehicles.push(vehicle);
            }
        }
    };
    SaleComponent.prototype.registerSale = function () {
        var saleToRegister = new __WEBPACK_IMPORTED_MODULE_4__entities_sale__["a" /* Sale */](this.buyerName, this.buyerPhoneNumber, this.sellingPrice);
        this._saleService.registerNewSale(this.selectedVehicleVIN, saleToRegister);
    };
    SaleComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-sale',
            template: __webpack_require__("../../../../../src/app/register-sale/sale.component.html"),
            styles: [__webpack_require__("../../../../../src/app/register-sale/sale.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__["a" /* VehicleService */],
            __WEBPACK_IMPORTED_MODULE_2__services_saleService__["a" /* SaleService */]])
    ], SaleComponent);
    return SaleComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-transport/transport.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "button#beginTransportBtn {\r\n    float: right;\r\n}\r\n\r\n.checkbox {\r\n    margin-left: 30px;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-transport/transport.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registro de transporte</h2>\r\n</div>\r\n<div [hidden]=\"!availableLots.length\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <table class='table table-bordered'>\r\n        <thead>\r\n            <tr>\r\n                <th>Agregar a transporte:</th>\r\n                <th>Nombre:</th>\r\n                <th>Descripción:</th>\r\n                <th>Creador:</th>\r\n                <th>Vehículos:</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor='let aLot of availableLots'>\r\n                <td> <input type=\"checkbox\" class=\"checkbox\" name=\"vehicle\" (change)=\"addOrRemoveLot(aLot.name)\" /></td>\r\n                <td>{{aLot.name}}</td>\r\n                <td>{{aLot.description}}</td>\r\n                <td>{{aLot.creatorUsername}}</td>\r\n                <td>{{aLot.vehicleVINs}}</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <br><br>\r\n    <button type=\"button\" class=\"btn btn-lg btn-success changeBtn\" (click)='beginTransport()' id=\"beginTransportBtn\">Iniciar transporte</button>\r\n</div>\r\n<div [hidden]=\"availableLots.length\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar: no existen lotes transportables.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-transport/transport.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TransportComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_lot_service__ = __webpack_require__("../../../../../src/app/services/lot.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_transport_service__ = __webpack_require__("../../../../../src/app/services/transport.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var TransportComponent = (function () {
    function TransportComponent(_lotService, _transportService) {
        this._lotService = _lotService;
        this._transportService = _transportService;
        this.transportedLotsNames = [];
        this.availableLots = [];
    }
    TransportComponent.prototype.addOrRemoveLot = function (lotName) {
        var index = this.transportedLotsNames.indexOf(lotName, 0);
        if (index > -1) {
            this.transportedLotsNames.splice(index, 1);
        }
        else {
            this.transportedLotsNames.push(lotName);
        }
    };
    TransportComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._lotService.getLots()
            .subscribe(function (lotsObtained) { return _this.initializeLots(lotsObtained); });
    };
    TransportComponent.prototype.initializeLots = function (lotsObtained) {
        for (var _i = 0, lotsObtained_1 = lotsObtained; _i < lotsObtained_1.length; _i++) {
            var lot = lotsObtained_1[_i];
            if (lot.isReadyForTransport) {
                this.availableLots.push(lot);
            }
        }
    };
    TransportComponent.prototype.beginTransport = function () {
        this._transportService.registerNewTransport(this.transportedLotsNames);
    };
    TransportComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'transport-component',
            template: __webpack_require__("../../../../../src/app/register-transport/transport.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/register-transport/transport.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_lot_service__["a" /* LotService */],
            __WEBPACK_IMPORTED_MODULE_2__services_transport_service__["a" /* TransportService */]])
    ], TransportComponent);
    return TransportComponent;
}());



/***/ }),

/***/ "../../../../../src/app/register-yard-inspection/yard-inspection.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "form#inspectionForm {\r\n    margin-top: 3%;\r\n    margin-left: 12%;\r\n}\r\n\r\nbutton#registerInspection {\r\n    margin-left: 15px;\r\n}\r\n\r\ndiv#damagesContainer {\r\n    background-color: white;\r\n    min-height: 150px;\r\n    text-align: center;\r\n}\r\n\r\ninput#descriptionTxt {\r\n    min-width: 350px;\r\n}\r\n\r\ninput.damageInput {\r\n    margin-right: 20px;\r\n}\r\n\r\nh3#addDamage {\r\n    font-weight: bold;\r\n}\r\n\r\nth#descriptionColumn {\r\n    min-width: 300px;\r\n    max-width: 475px;\r\n}\r\n\r\ntd.descriptionCell {\r\n    max-width: 475px;\r\n    overflow-wrap: break-word;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/register-yard-inspection/yard-inspection.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Registro de Inspección de Patio</h2>\r\n</div>\r\n<div class=\"container\">\r\n    <div [hidden]=\"vehicles.length == 0 || yardNames.length == 0\" id=\"contentsContainer\">\r\n        <div class=\"row\">\r\n            <form class=\"form-horizontal col-lg-10\" (ngSubmit)=\"registerYardInspection()\" #inspectionForm=\"ngForm\" name=\"inspectionForm\" role=\"form\" id=\"inspectionForm\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"nameTxt\">Vehículo:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <select class=\"form-control\" [(ngModel)]=\"selectedVehicle\" (change)=\"updateInspectionDamages()\" required name=\"vehicleSelect\" id=\"vehicleSelect\">\r\n                          <option *ngFor='let aVehicle of vehicles' [ngValue]=\"aVehicle\">{{aVehicle.vin}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"email\">Ubicación:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <select class=\"form-control\" [(ngModel)]=\"selectedLocation\" required name=\"locationSelect\" id=\"locationSelect\">\r\n                          <option *ngFor='let aName of yardNames' [ngValue]=\"aName\">{{aName}}</option>\r\n                        </select>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div><br>\r\n        <h3 id=\"addDamage\">Agregar daño:</h3><br>\r\n        <form class=\"form-inline\" #damageForm=\"ngForm\" (ngSubmit)=\"attemptToAddDamage()\" name=\"damageForm\">\r\n            <div class=\"form-group\">\r\n                <label for=\"descriptionTxt\">Descripción:</label>\r\n                <input type=\"text\" required class=\"form-control damageInput\" pattern=\".*[a-zA-Z].*$\" id=\"descriptionTxt\" [(ngModel)]=\"damageDescription\" name=\"description\">\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label for=\"imageFileChooser\">Imágenes:</label>\r\n                <input type=\"file\" name=\"pic\" required accept=\"image/*\" multiple (change)=\"getFiles($event)\" class=\"form-control damageInput\" id=\"imageFileChooser\">\r\n            </div>\r\n            <button type=\"submit\" [disabled]=\"damageForm.invalid\" class=\"btn btn-default btn-danger\" name=\"addDamage\" id=\"addDamage\">Agregar daño</button>\r\n            <div class=\"row\">\r\n                <br>\r\n            </div>\r\n            <div class=\"row\" id=\"damagesContainer\">\r\n                <table [hidden]=\"!damages.length\" class='table table-bordered'>\r\n                    <thead>\r\n                        <tr>\r\n                            <th id=\"descriptionColumn\">Descripción:</th>\r\n                            <th>Imágenes:</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr *ngFor='let damage of damages'>\r\n                            <td class=\"descriptionCell\">{{damage.description}}</td>\r\n                            <td>\r\n                                <img class=\"img-thumbnail\" *ngFor='let image of damage.images' [src]=\"_DomSanitizer.bypassSecurityTrustUrl(image)\" width=\"250\" height=\"auto\" alt=\"Evidencia de daño.\">\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n                <span [hidden]=\"damages.length\">\r\n              <br><br>\r\n              <h4>Inspección sin daños.</h4>\r\n            </span>\r\n            </div><br>\r\n            <button type=\"reset\" class=\"btn btn-lg btn-primary changeBtn\" (click)='clearDamages()'>Reestablecer</button>\r\n            <button type=\"submit\" form=\"inspectionForm\" [disabled]=\"inspectionForm.invalid\" class=\"btn btn-lg btn-success changeBtn\" id=\"registerInspection\">Confirmar</button>\r\n        </form>\r\n    </div>\r\n    <div [hidden]=\"vehicles.length > 0 && yardNames.length > 0\" id=\"noContentsContainer\">\r\n        <br><br><br><br><br>\r\n        <h3>No existen vehículos inspeccionables.</h3>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/register-yard-inspection/yard-inspection.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return YardInspectionComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__services_location_service__ = __webpack_require__("../../../../../src/app/services/location.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__entities_damage__ = __webpack_require__("../../../../../src/app/entities/damage.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__entities_inspection__ = __webpack_require__("../../../../../src/app/entities/inspection.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__ = __webpack_require__("../../../../../src/app/services/inspection.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var YardInspectionComponent = (function () {
    function YardInspectionComponent(_DomSanitizer, _inspectionService, _vehicleService, _locationService) {
        this._DomSanitizer = _DomSanitizer;
        this._inspectionService = _inspectionService;
        this._vehicleService = _vehicleService;
        this._locationService = _locationService;
        this.vehicles = [];
        this.yardNames = [];
        this.damages = [];
    }
    YardInspectionComponent.prototype.getFiles = function (event) {
        this.imageFiles = event.target.files;
    };
    YardInspectionComponent.prototype.attemptToAddDamage = function () {
        if (this.imageFiles.length > 0) {
            var images = this.getImageStrings();
            this.damages.push(new __WEBPACK_IMPORTED_MODULE_3__entities_damage__["a" /* Damage */](this.damageDescription, images));
            alert("Daño agregado exitosamente.");
        }
        else {
            alert("Error: es necesario ayardar evidencia fotográfica para"
                + " poder registrar un daño.");
        }
    };
    YardInspectionComponent.prototype.updateInspectionDamages = function () {
        var _this = this;
        var inspectionIdToFind = this.selectedVehicle.portInspectionId;
        this._inspectionService.getInspectionWithId(inspectionIdToFind)
            .subscribe(function (foundInspection) { return _this.damages = foundInspection.damages; });
    };
    YardInspectionComponent.prototype.getImageStrings = function () {
        var stringifiedImages = [];
        for (var i = 0; i < this.imageFiles.length; i++) {
            var file = this.imageFiles[i];
            if (!file.type.match('image.*')) {
                throw "Sólo se aceptan imágenes para este campo.";
            }
            this.getImageData(file, stringifiedImages);
        }
        return stringifiedImages;
    };
    YardInspectionComponent.prototype.getImageData = function (file, stringifiedImages) {
        var reader = new FileReader();
        reader.onload = function (e) {
            stringifiedImages.push(reader.result);
        };
        reader.readAsDataURL(file);
    };
    YardInspectionComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getVehicles()
            .subscribe(function (obtainedVehicles) { return _this.initializeVehicles(obtainedVehicles); });
        this._locationService.getYards()
            .subscribe(function (yardsObtained) { return _this.yardNames = yardsObtained; });
    };
    YardInspectionComponent.prototype.initializeVehicles = function (obtainedVehicles) {
        for (var _i = 0, obtainedVehicles_1 = obtainedVehicles; _i < obtainedVehicles_1.length; _i++) {
            var vehicle = obtainedVehicles_1[_i];
            if (vehicle.currentStage.indexOf(__WEBPACK_IMPORTED_MODULE_7__environments_environment__["a" /* environment */].YARD_STAGE_PREFIX) !== -1
                && !vehicle.hasYardInspection) {
                this.vehicles.push(vehicle);
            }
        }
    };
    YardInspectionComponent.prototype.clearDamages = function () {
        this.damages = [];
    };
    YardInspectionComponent.prototype.registerYardInspection = function () {
        var inspectionToRegister = new __WEBPACK_IMPORTED_MODULE_5__entities_inspection__["a" /* Inspection */](this.selectedLocation, new Date().toUTCString(), this.damages);
        this._inspectionService.registerYardInspection(this.selectedVehicle.vin, inspectionToRegister);
    };
    YardInspectionComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-yard-inspection',
            template: __webpack_require__("../../../../../src/app/register-yard-inspection/yard-inspection.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/register-yard-inspection/yard-inspection.component.css")],
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_4__angular_platform_browser__["b" /* DomSanitizer */], __WEBPACK_IMPORTED_MODULE_6__services_inspection_service__["a" /* InspectionService */],
            __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__["a" /* VehicleService */], __WEBPACK_IMPORTED_MODULE_2__services_location_service__["a" /* LocationService */]])
    ], YardInspectionComponent);
    return YardInspectionComponent;
}());



/***/ }),

/***/ "../../../../../src/app/sale-list/sale-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Ventas</h2>\r\n</div>\r\n<div [hidden]=\"sales.length == 0\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <table class='table table-bordered'>\r\n        <thead>\r\n            <tr>\r\n                <th>VIN del vehículo:</th>\r\n                <th>Nombre del comprador:</th>\r\n                <th>Teléfono del comprador:</th>\r\n                <th>Precio de venta:</th>\r\n                <th>Fecha y hora:</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor='let aSale of sales'>\r\n                <td>{{aSale.vehicleVIN}}</td>\r\n                <td>{{aSale.customerName}}</td>\r\n                <td>{{aSale.customerPhoneNumber}}</td>\r\n                <td>{{aSale.sellingPrice}}</td>\r\n                <td>{{aSale.dateTime}}</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<div [hidden]=\"sales.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/sale-list/sale-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SaleListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_saleService__ = __webpack_require__("../../../../../src/app/services/saleService.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var SaleListComponent = (function () {
    function SaleListComponent(_saleService) {
        this._saleService = _saleService;
        this.sales = [];
    }
    SaleListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._saleService.getSales()
            .subscribe(function (salesObtained) { return _this.sales = salesObtained; });
    };
    SaleListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-sale-list',
            template: __webpack_require__("../../../../../src/app/sale-list/sale-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_saleService__["a" /* SaleService */]])
    ], SaleListComponent);
    return SaleListComponent;
}());



/***/ }),

/***/ "../../../../../src/app/services/base.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BaseService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__("../../../../rxjs/_esm5/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var BaseService = (function () {
    function BaseService(_httpService) {
        this._httpService = _httpService;
    }
    BaseService.prototype.getHeader = function () {
        return new __WEBPACK_IMPORTED_MODULE_2__angular_http__["a" /* Headers */]({
            'Authorization': 'Bearer '.concat(sessionStorage.getItem("token")),
            'Content-Type': 'application/json'
        });
    };
    BaseService.prototype.handleError = function (error) {
        console.error(error);
        var errorBody = error.json();
        var message = errorBody["message"];
        if (!message) {
            message = "Error al establecerse una conexion con el servidor.";
        }
        alert(message);
        return __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["a" /* Observable */].throw(error);
    };
    BaseService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_2__angular_http__["b" /* Http */]])
    ], BaseService);
    return BaseService;
}());



/***/ }),

/***/ "../../../../../src/app/services/inspection.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return InspectionService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var InspectionService = (function (_super) {
    __extends(InspectionService, _super);
    function InspectionService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    InspectionService_1 = InspectionService;
    InspectionService.prototype.registerPortInspection = function (vehicleVIN, inspectionToAdd) {
        var _this = this;
        var url = InspectionService_1.URL + vehicleVIN + "/PortInspection";
        var header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(inspectionToAdd), { 'headers': header })
            .map(function (response) { return alert("Inspección de puerto registrada correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    InspectionService.prototype.registerYardInspection = function (vehicleVIN, inspectionToAdd) {
        var _this = this;
        var url = InspectionService_1.URL + vehicleVIN + "/YardInspection";
        var header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(inspectionToAdd), { 'headers': header })
            .map(function (response) { return alert("Inspección de patio registrada correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    InspectionService.prototype.getInspectionWithId = function (idToFind) {
        var url = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Inspections/" + idToFind;
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    InspectionService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Vehicles/";
    InspectionService = InspectionService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], InspectionService);
    return InspectionService;
    var InspectionService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/location.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LocationService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var LocationService = (function (_super) {
    __extends(LocationService, _super);
    function LocationService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    LocationService_1 = LocationService;
    LocationService.prototype.getPorts = function () {
        var url = LocationService_1.URL + "/Ports";
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    LocationService.prototype.getYards = function () {
        var url = LocationService_1.URL + "/Yards";
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    LocationService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Locations";
    LocationService = LocationService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], LocationService);
    return LocationService;
    var LocationService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/login-service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LoginService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var LoginService = (function () {
    function LoginService(_httpService, _router) {
        this._httpService = _httpService;
        this._router = _router;
    }
    LoginService_1 = LoginService;
    LoginService.prototype.successfulLogin = function (component) {
        var _this = this;
        component.success = true;
        setTimeout(function () {
            _this._router.navigateByUrl('/app');
        }, 1500);
    };
    LoginService.prototype.processLogin = function (username, response, component) {
        var responseData = response.json();
        sessionStorage.setItem("username", username);
        sessionStorage.setItem("role", responseData["role"]);
        sessionStorage.setItem("token", responseData["access_token"]);
        this.successfulLogin(component);
    };
    LoginService.prototype.showError = function (error, component) {
        console.error(error);
        var message = error.json()["error_description"];
        if (!message) {
            message = "Error al establecerse una conexion con el servidor.";
        }
        component.errorMessage = message;
        component.errorOcurred = true;
        setTimeout(function () {
            component.errorOcurred = false;
        }, 3000);
    };
    LoginService.prototype.attemptLoginWithData = function (username, password, component) {
        var _this = this;
        var header = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["a" /* Headers */]({
            'Content-Type': 'application/x-www-form-urlencoded'
        });
        var body = new URLSearchParams();
        body.set('grant_type', 'password');
        body.set('username', username);
        body.set('password', password);
        this._httpService.post(LoginService_1.LOGIN_URL, body.toString(), { 'headers': header }).map(function (response) {
            _this.processLogin(username, response, component);
        }).subscribe(null, function (err) { return _this.showError(err, component); });
    };
    LoginService.LOGIN_URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + '/login';
    LoginService = LoginService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */],
            __WEBPACK_IMPORTED_MODULE_3__angular_router__["b" /* Router */]])
    ], LoginService);
    return LoginService;
    var LoginService_1;
}());



/***/ }),

/***/ "../../../../../src/app/services/lot.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return LotService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var LotService = (function (_super) {
    __extends(LotService, _super);
    function LotService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    LotService_1 = LotService;
    LotService.prototype.getLots = function () {
        var header = this.getHeader();
        return this._httpService.get(LotService_1.URL, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    LotService.prototype.registerNewLot = function (lotToAdd) {
        var _this = this;
        var header = this.getHeader();
        return this._httpService.post(LotService_1.URL, JSON.stringify(lotToAdd), { 'headers': header })
            .map(function (response) { return alert("Lote creado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    LotService.prototype.deleteLotWithName = function (nameOfLotToDelete) {
        var _this = this;
        var url = LotService_1.URL + "/" + nameOfLotToDelete;
        var header = this.getHeader();
        return this._httpService.delete(url, { 'headers': header })
            .map(function (response) { return alert("Lote eliminado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    LotService.prototype.getLotWithName = function (nameOfLotToFind) {
        var url = LotService_1.URL + "/" + nameOfLotToFind;
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    LotService.prototype.editLotWithName = function (nameOfLotTOEdit, lotData) {
        var _this = this;
        var url = LotService_1.URL + "/" + nameOfLotTOEdit;
        var header = this.getHeader();
        return this._httpService.put(url, JSON.stringify(lotData), { 'headers': header })
            .map(function (response) { return alert("Lote modificado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    LotService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Lots";
    LotService = LotService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], LotService);
    return LotService;
    var LotService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/movement.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return MovementService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var MovementService = (function (_super) {
    __extends(MovementService, _super);
    function MovementService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    MovementService_1 = MovementService;
    MovementService.prototype.registerNewMovement = function (arrival, VehicleVin) {
        var _this = this;
        var url = MovementService_1.URL + VehicleVin + "/Movements";
        var header = this.getHeader();
        var body = { "DateTime": new Date(), "ArrivalSubzoneId": arrival };
        return this._httpService.post(url, body, { 'headers': header })
            .map(function (response) { return alert("Movimiento registrado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    MovementService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Vehicles/";
    MovementService = MovementService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], MovementService);
    return MovementService;
    var MovementService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/saleService.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SaleService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var SaleService = (function (_super) {
    __extends(SaleService, _super);
    function SaleService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    SaleService.prototype.getSales = function () {
        var url = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Sales";
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    SaleService.prototype.registerNewSale = function (vehicleVIN, saleToAdd) {
        var _this = this;
        var url = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Vehicles/" + vehicleVIN + "/Sale";
        var header = this.getHeader();
        return this._httpService.post(url, JSON.stringify(saleToAdd), { 'headers': header })
            .map(function (response) { return alert("Venta registrada correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    SaleService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], SaleService);
    return SaleService;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/subzone.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SubzoneService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var SubzoneService = (function (_super) {
    __extends(SubzoneService, _super);
    function SubzoneService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    SubzoneService_1 = SubzoneService;
    SubzoneService.prototype.getSubzones = function () {
        var header = this.getHeader();
        return this._httpService.get(SubzoneService_1.URL, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    SubzoneService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Subzones";
    SubzoneService = SubzoneService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], SubzoneService);
    return SubzoneService;
    var SubzoneService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/transport.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TransportService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var TransportService = (function (_super) {
    __extends(TransportService, _super);
    function TransportService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    TransportService_1 = TransportService;
    TransportService.prototype.getTransports = function () {
        var header = this.getHeader();
        return this._httpService.get(TransportService_1.URL, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    TransportService.prototype.registerNewTransport = function (transportedLotsNames) {
        var _this = this;
        var header = this.getHeader();
        var body = { "StartDateTime": new Date(), "TransportedLotsNames": transportedLotsNames };
        return this._httpService.post(TransportService_1.URL, body, { 'headers': header })
            .map(function (response) { return alert("Transporte registrado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    TransportService.prototype.finalizeTransportWithId = function (transportId) {
        var _this = this;
        var url = TransportService_1.URL + "/" + transportId;
        var header = this.getHeader();
        var body = new Date();
        return this._httpService.put(url, body, { 'headers': header })
            .map(function (response) { return alert("Transporte de ID \"" + transportId +
            "\" finalizado correctamente."); })
            .subscribe(null, function (err) { return _this.handleError(err); });
    };
    TransportService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Transports";
    TransportService = TransportService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], TransportService);
    return TransportService;
    var TransportService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/services/vehicle.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VehicleService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/esm5/http.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/_esm5/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__base_service__ = __webpack_require__("../../../../../src/app/services/base.service.ts");
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var VehicleService = (function (_super) {
    __extends(VehicleService, _super);
    function VehicleService(_httpService) {
        return _super.call(this, _httpService) || this;
    }
    VehicleService_1 = VehicleService;
    VehicleService.prototype.getVehicles = function () {
        var header = this.getHeader();
        return this._httpService.get(VehicleService_1.URL, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    VehicleService.prototype.getHistoryOfVehicleWithVIN = function (vinToFind) {
        var url = VehicleService_1.URL + "/" + vinToFind + "/History";
        var header = this.getHeader();
        return this._httpService.get(url, { 'headers': header })
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    VehicleService.URL = __WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].APIURL + "/api/Vehicles";
    VehicleService = VehicleService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["A" /* Injectable */])(),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]])
    ], VehicleService);
    return VehicleService;
    var VehicleService_1;
}(__WEBPACK_IMPORTED_MODULE_5__base_service__["a" /* BaseService */]));



/***/ }),

/***/ "../../../../../src/app/styles/list-styles.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "html,\r\nbody {\r\n    background-color: darkgray;\r\n}\r\n\r\n* {\r\n    box-sizing: border-box;\r\n}\r\n\r\nul {\r\n    margin: 0;\r\n    padding: 0;\r\n}\r\n\r\nth {\r\n    text-align: center;\r\n    background-color: black;\r\n    color: white;\r\n}\r\n\r\nul li {\r\n    cursor: pointer;\r\n    position: relative;\r\n    padding: 12px 8px 12px 40px;\r\n    list-style-type: none;\r\n    background: #eee;\r\n    font-size: 18px;\r\n    transition: 0.2s;\r\n    -webkit-user-select: none;\r\n    -moz-user-select: none;\r\n    -ms-user-select: none;\r\n    user-select: none;\r\n}\r\n\r\nul li:nth-child(odd) {\r\n    background: #f9f9f9;\r\n}\r\n\r\nul li:hover {\r\n    background: #ddd;\r\n}\r\n\r\nul li.checked {\r\n    background: #888;\r\n    color: #fff;\r\n}\r\n\r\nul li.checked::before {\r\n    content: '';\r\n    position: absolute;\r\n    border-color: #fff;\r\n    border-style: solid;\r\n    border-width: 0 2px 2px 0;\r\n    top: 10px;\r\n    left: 16px;\r\n    -webkit-transform: rotate(45deg);\r\n            transform: rotate(45deg);\r\n    height: 15px;\r\n    width: 7px;\r\n}\r\n\r\n.close {\r\n    position: absolute;\r\n    right: 0;\r\n    top: 0;\r\n    padding: 12px 16px 12px 16px;\r\n}\r\n\r\n.close:hover {\r\n    background-color: #f44336;\r\n    color: white;\r\n}\r\n\r\n.header:after {\r\n    content: \"\";\r\n    display: table;\r\n    clear: both;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/transport-list/transport-list.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "button#finalizeTransportBtn {\r\n    float: right;\r\n}\r\n\r\ninput.transportRadiobutton {\r\n    margin-left: 13%;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/transport-list/transport-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Transportes</h2>\r\n</div>\r\n<div [hidden]=\"!transports.length\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <table class='table table-bordered'>\r\n        <thead>\r\n            <tr>\r\n                <th></th>\r\n                <th>ID:</th>\r\n                <th>Transportador:</th>\r\n                <th>Inicio:</th>\r\n                <th>Lotes transportados:</th>\r\n                <th>Fin:</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor='let aTransport of transports'>\r\n                <td>\r\n                    <input name=\"transportSelector\" class=\"transportRadiobutton\" type=\"radio\" (click)=\"setSelectedTransportId(aTransport)\" />\r\n                </td>\r\n                <td>{{aTransport.id}}</td>\r\n                <td>{{aTransport.transporterUsername}}</td>\r\n                <td>{{prettyPrintDate(aTransport.startDateTime)}}</td>\r\n                <td>{{aTransport.transportedLotsNames}}</td>\r\n                <td>{{prettyPrintDate(aTransport.endDateTime)}}</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <br><br>\r\n    <button type=\"button\" class=\"btn btn-lg btn-success changeBtn\" [disabled]=\"selectedTransport == null || selectedTransport.endDateTime != null\" (click)='finalizeSelectedTransport()' id=\"finalizeTransportBtn\">Finalizar transporte</button>\r\n</div>\r\n<div [hidden]=\"transports.length\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/transport-list/transport-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return TransportListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_transport_service__ = __webpack_require__("../../../../../src/app/services/transport.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var TransportListComponent = (function () {
    function TransportListComponent(_transportService) {
        this._transportService = _transportService;
        this.transports = [];
    }
    TransportListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._transportService.getTransports()
            .subscribe(function (transportsObtained) { return _this.transports = transportsObtained; });
    };
    TransportListComponent.prototype.setSelectedTransportId = function (transport) {
        this.selectedTransport = transport;
    };
    TransportListComponent.prototype.finalizeSelectedTransport = function () {
        this._transportService.finalizeTransportWithId(this.selectedTransport.id);
    };
    TransportListComponent.prototype.prettyPrintDate = function (someDate) {
        if (someDate == null) {
            return "N/a";
        }
        else {
            return new Date(someDate).toLocaleString();
        }
    };
    TransportListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-transport-list',
            template: __webpack_require__("../../../../../src/app/transport-list/transport-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/transport-list/transport-list.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_transport_service__["a" /* TransportService */]])
    ], TransportListComponent);
    return TransportListComponent;
}());



/***/ }),

/***/ "../../../../../src/app/vehicle-history/vehicle-history.component.css":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "form#inspectionForm {\r\n    margin-top: 3%;\r\n    margin-left: 12%;\r\n}\r\n\r\nbutton#registerInspection {\r\n    margin-left: 15px;\r\n}\r\n\r\ndiv#damagesContainer {\r\n    background-color: white;\r\n    min-height: 100px;\r\n    max-width: 100%;\r\n    text-align: center;\r\n}\r\n\r\ninput#descriptionTxt {\r\n    min-width: 350px;\r\n}\r\n\r\ninput.damageInput {\r\n    margin-right: 20px;\r\n}\r\n\r\nh3#addDamage {\r\n    font-weight: bold;\r\n}", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/vehicle-history/vehicle-history.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Historial del vehículo: {{vehicleVIN}}</h2>\r\n</div>\r\n<div class=\"container\">\r\n    <br><br>\r\n    <div [hidden]=\"hasNoLotData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Información de Lote</div>\r\n        <div class=\"panel-body\">\r\n            <table class='table table-bordered'>\r\n                <thead>\r\n                    <tr>\r\n                        <th>Nombre:</th>\r\n                        <th>Descripción:</th>\r\n                        <th>Creador:</th>\r\n                        <th>Vehículos:</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr>\r\n                        <td>{{lotData.name}}</td>\r\n                        <td>{{lotData.description}}</td>\r\n                        <td>{{lotData.creatorUsername}}</td>\r\n                        <td>{{lotData.vehicleVINs}}</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"hasNoPortInspectionData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Información de inspección de puerto</div>\r\n        <div class=\"panel-body\">\r\n            <form class=\"form-horizontal col-lg-9 col-lg-offset-2\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"vehicleName\">Vehículo:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{portInspectionData.vehicleVIN}}\" required name=\"vehicleName\" id=\"vehicleName\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"locationName\">Ubicación:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{portInspectionData.locationName}}\" required name=\"locationName\" id=\"locationName\">\r\n                    </div>\r\n                </div>\r\n            </form>\r\n            <br><br><br><br><br>\r\n            <h3 id=\"addDamage\">Daños:</h3>\r\n            <div id=\"damagesContainer\">\r\n                <table [hidden]=\"portInspectionData.damages.length === 0\" class='table table-bordered'>\r\n                    <thead>\r\n                        <tr>\r\n                            <th id=\"descriptionColumn\">Descripción:</th>\r\n                            <th>Imágenes:</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr *ngFor='let damage of portInspectionData.damages'>\r\n                            <td class=\"descriptionCell\">{{damage.description}}</td>\r\n                            <td>\r\n                                <img class=\"img-thumbnail\" *ngFor='let image of damage.images' [src]=\"_DomSanitizer.bypassSecurityTrustUrl(image)\" width=\"250\" height=\"auto\" alt=\"Evidencia de daño.\">\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n                <span [hidden]=\"portInspectionData.damages.length > 0\">\r\n                    <br><br><h4>Inspección sin daños.</h4>\r\n                </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"hasNoTransportData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Información de transporte</div>\r\n        <div class=\"panel-body\">\r\n            <form class=\"form-horizontal col-lg-8 col-lg-offset-2\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"transporterUsername\">Transportador:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{transportData.transporterUsername}}\" name=\"transporterUsername\" id=\"transporterUsername\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"startDateTime\">Fecha de Inicio:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{prettyPrintDate(transportData.startDateTime)}}\" name=\"startDateTime\" id=\"startDateTime\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"endDateTime\">Fecha de Fin:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{prettyPrintDate(transportData.endDateTime)}}\" name=\"endDateTime\" id=\"endDateTime\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"transportedLots\">Lotes transportados:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <textarea rows=\"4\" required class=\"form-control\" disabled id=\"description\" value=\"{{transportData.transportedLotsNames}}\" name=\"transportedLots\" id=\"transportedLots\"></textarea>\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"hasNoYardInspectionData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Información de inspección de patio</div>\r\n        <div class=\"panel-body\">\r\n            <form class=\"form-horizontal col-lg-9 col-lg-offset-2\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-2\" for=\"yardLocationName\">Ubicación:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" class=\"form-control\" disabled value=\"{{yardInspectionData.locationName}}\" required name=\"yardLocationName\" id=\"yardLocationName\">\r\n                    </div>\r\n                </div>\r\n            </form>\r\n            <br><br><br><br><br>\r\n            <h3 id=\"addDamage\">Daños:</h3>\r\n            <div id=\"damagesContainer\">\r\n                <table [hidden]=\"yardInspectionData.damages.length === 0\" class='table table-bordered'>\r\n                    <thead>\r\n                        <tr>\r\n                            <th id=\"descriptionColumn\">Descripción:</th>\r\n                            <th>Imágenes:</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n                        <tr *ngFor='let damage of yardInspectionData.damages'>\r\n                            <td class=\"descriptionCell\">{{damage.description}}</td>\r\n                            <td>\r\n                                <img class=\"img-thumbnail\" *ngFor='let image of damage.images' [src]=\"_DomSanitizer.bypassSecurityTrustUrl(image)\" width=\"250\" height=\"auto\" alt=\"Evidencia de daño.\">\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n                <span [hidden]=\"yardInspectionData.damages.length > 0\">\r\n                        <br><br><h4>Inspección sin daños.</h4>\r\n                    </span>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"hasNoMovementsData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Movimientos en patio</div>\r\n        <div class=\"panel-body\">\r\n            <table class='table table-bordered'>\r\n                <thead>\r\n                    <tr>\r\n                        <th>Responsable:</th>\r\n                        <th>Origen:</th>\r\n                        <th>Destino:</th>\r\n                        <th>Fecha y Hora:</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr *ngFor='let movement of movementsData'>\r\n                        <td>{{movement.responsiblesUsername}}</td>\r\n                        <td>{{movement.departureSubzone}}</td>\r\n                        <td>{{movement.arrivalSubzone}}</td>\r\n                        <td>{{prettyPrintDate(movement.dateTime)}}</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"hasNoSaleData\" class=\"panel panel-primary\">\r\n        <div class=\"panel-heading\">Información de venta</div>\r\n        <div class=\"panel-body\">\r\n            <form class=\"form-horizontal col-lg-10\" name=\"saleForm\" role=\"form\" id=\"saleForm\">\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"buyerName\">Nombre del comprador:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" disabled class=\"form-control\" id=\"buyerName\" value=\"{{saleData.buyerName}}\" name=\"buyerName\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"buyerPhoneNumber\">Teléfono del comprador:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" disabled class=\"form-control\" id=\"buyerPhoneNumber\" value=\"{{saleData.buyerPhoneNumber}}\" name=\"buyerPhoneNumber\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"sellingPrice\">Precio de venta:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"number\" disabled class=\"form-control\" id=\"sellingPrice\" value=\"{{saleData.sellingPrice}}\" name=\"sellingPrice\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <label class=\"control-label col-lg-3\" for=\"saleDate\">Fecha:</label>\r\n                    <div class=\"col-lg-7\">\r\n                        <input type=\"text\" disabled class=\"form-control\" id=\"saleDate\" value=\"{{prettyPrintDate(saleData.dateTime)}}\" name=\"saleDate\">\r\n                    </div>\r\n                </div>\r\n            </form>\r\n        </div>\r\n    </div>\r\n\r\n    <div [hidden]=\"!hasNoLotData || !hasNoPortInspectionData\" id=\"noContentsContainer\">\r\n        <br><br><br><br><br>\r\n        <h3>Sin datos asociados al proceso del vehículo seleccionado.</h3>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/vehicle-history/vehicle-history.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VehicleHistoryComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__entities_lot__ = __webpack_require__("../../../../../src/app/entities/lot.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__entities_inspection__ = __webpack_require__("../../../../../src/app/entities/inspection.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__entities_sale__ = __webpack_require__("../../../../../src/app/entities/sale.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__entities_transport__ = __webpack_require__("../../../../../src/app/entities/transport.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__angular_platform_browser__ = __webpack_require__("../../../platform-browser/esm5/platform-browser.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var VehicleHistoryComponent = (function () {
    function VehicleHistoryComponent(_currentRoute, _DomSanitizer, _vehicleService) {
        this._currentRoute = _currentRoute;
        this._DomSanitizer = _DomSanitizer;
        this._vehicleService = _vehicleService;
        this.vehicleVIN = this._currentRoute.snapshot.params['vehicleVIN'];
        this.lotData = new __WEBPACK_IMPORTED_MODULE_2__entities_lot__["a" /* Lot */]();
        this.portInspectionData = new __WEBPACK_IMPORTED_MODULE_3__entities_inspection__["a" /* Inspection */]();
        this.transportData = new __WEBPACK_IMPORTED_MODULE_6__entities_transport__["a" /* Transport */]();
        this.yardInspectionData = new __WEBPACK_IMPORTED_MODULE_3__entities_inspection__["a" /* Inspection */]();
        this.movementsData = [];
        this.saleData = new __WEBPACK_IMPORTED_MODULE_4__entities_sale__["a" /* Sale */]();
        this.hasNoLotData = true;
        this.hasNoPortInspectionData = true;
        this.hasNoTransportData = true;
        this.hasNoYardInspectionData = true;
        this.hasNoMovementsData = true;
        this.hasNoSaleData = true;
    }
    VehicleHistoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getHistoryOfVehicleWithVIN(this.vehicleVIN)
            .subscribe(function (obtainedHistory) { return _this.initializeAttributes(obtainedHistory); });
    };
    // Even when hiding HTML components, angular failed on null attributes.
    VehicleHistoryComponent.prototype.initializeAttributes = function (obtainedHistory) {
        if (obtainedHistory.lotData == null) {
            this.lotData = new __WEBPACK_IMPORTED_MODULE_2__entities_lot__["a" /* Lot */]();
            this.hasNoLotData = true;
        }
        else {
            this.lotData = obtainedHistory.lotData;
            this.hasNoLotData = false;
        }
        if (obtainedHistory.portInspectionData == null) {
            this.portInspectionData = new __WEBPACK_IMPORTED_MODULE_3__entities_inspection__["a" /* Inspection */]();
            this.hasNoPortInspectionData = true;
        }
        else {
            this.portInspectionData = obtainedHistory.portInspectionData;
            this.hasNoPortInspectionData = false;
        }
        if (obtainedHistory.transportData == null) {
            this.transportData = new __WEBPACK_IMPORTED_MODULE_6__entities_transport__["a" /* Transport */]();
            this.hasNoTransportData = true;
        }
        else {
            this.transportData = obtainedHistory.transportData;
            this.hasNoTransportData = false;
        }
        if (obtainedHistory.yardInspectionData == null) {
            this.yardInspectionData = new __WEBPACK_IMPORTED_MODULE_3__entities_inspection__["a" /* Inspection */]();
            this.hasNoYardInspectionData = true;
        }
        else {
            this.yardInspectionData = obtainedHistory.yardInspectionData;
            this.hasNoYardInspectionData = false;
        }
        this.movementsData = obtainedHistory.movementsData;
        this.hasNoMovementsData = obtainedHistory.movementsData.length == 0;
        if (obtainedHistory.saleData == null) {
            this.saleData = new __WEBPACK_IMPORTED_MODULE_4__entities_sale__["a" /* Sale */]();
            this.hasNoSaleData = true;
        }
        else {
            this.saleData = obtainedHistory.saleData;
            this.hasNoSaleData = false;
        }
    };
    VehicleHistoryComponent.prototype.prettyPrintDate = function (someDate) {
        if (someDate == null) {
            return "N/a";
        }
        else {
            return new Date(someDate).toLocaleString();
        }
    };
    VehicleHistoryComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-vehicle-history',
            template: __webpack_require__("../../../../../src/app/vehicle-history/vehicle-history.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css"), __webpack_require__("../../../../../src/app/vehicle-history/vehicle-history.component.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */], __WEBPACK_IMPORTED_MODULE_7__angular_platform_browser__["b" /* DomSanitizer */],
            __WEBPACK_IMPORTED_MODULE_5__services_vehicle_service__["a" /* VehicleService */]])
    ], VehicleHistoryComponent);
    return VehicleHistoryComponent;
}());



/***/ }),

/***/ "../../../../../src/app/vehicle-list/vehicle-list.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"header\">\r\n    <br><br>\r\n    <h2 class=\"contentsTitle\">Vehículos</h2>\r\n</div>\r\n<div [hidden]=\"vehicles.length == 0\" id=\"contentsContainer\">\r\n    <br><br>\r\n    <table class='table table-bordered'>\r\n        <thead>\r\n            <tr>\r\n                <th>VIN:</th>\r\n                <th>Tipo:</th>\r\n                <th>Marca:</th>\r\n                <th>Modelo:</th>\r\n                <th>Color:</th>\r\n                <th>Año:</th>\r\n                <th>Etapa actual:</th>\r\n                <th>Ver histórico:</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr *ngFor='let aVehicle of vehicles'>\r\n                <td>{{aVehicle.vin}}</td>\r\n                <td>{{prettyPrintType(aVehicle.type)}}</td>\r\n                <td>{{aVehicle.brand}}</td>\r\n                <td>{{aVehicle.model}}</td>\r\n                <td>{{aVehicle.color}}</td>\r\n                <td>{{aVehicle.year}}</td>\r\n                <td>{{aVehicle.currentStage}}</td>\r\n                <td>\r\n                    <button type=\"button\" class=\"btn btn-info\" (click)=\"openVehicleHistoryFor(aVehicle.vin)\">\r\n                        <span class=\"glyphicon glyphicon-search\"></span>\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n<div [hidden]=\"vehicles.length > 0\" id=\"noContentsContainer\">\r\n    <br><br><br><br><br>\r\n    <h3>Sin datos a mostrar.</h3>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/vehicle-list/vehicle-list.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return VehicleListComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__ = __webpack_require__("../../../../../src/app/services/vehicle.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_router__ = __webpack_require__("../../../router/esm5/router.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__ = __webpack_require__("../../../../../src/environments/environment.prod.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var VehicleListComponent = (function () {
    function VehicleListComponent(_vehicleService, _router) {
        this._vehicleService = _vehicleService;
        this._router = _router;
        this.vehicles = [];
    }
    VehicleListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._vehicleService.getVehicles()
            .subscribe(function (vehiclesObtained) { return _this.vehicles = vehiclesObtained; });
    };
    VehicleListComponent.prototype.openVehicleHistoryFor = function (vehicleVin) {
        this._router.navigate(['/app/vehicleHistory', vehicleVin]);
    };
    VehicleListComponent.prototype.prettyPrintType = function (type) {
        if (type == __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__["a" /* environment */].CAR_TYPE) {
            return "Automóvil";
        }
        else if (type == __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__["a" /* environment */].TRUCK_TYPE) {
            return "Camión";
        }
        else if (type == __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__["a" /* environment */].SUV_TYPE) {
            return "SUV";
        }
        else if (type == __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__["a" /* environment */].VAN_TYPE) {
            return "Camioneta";
        }
        else if (type == __WEBPACK_IMPORTED_MODULE_3__environments_environment_prod__["a" /* environment */].MINI_VAN_TYPE) {
            return "Mini-van";
        }
        else {
            return "Tipo desconocido";
        }
    };
    VehicleListComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
            selector: 'app-vehicle-list',
            template: __webpack_require__("../../../../../src/app/vehicle-list/vehicle-list.component.html"),
            styles: [__webpack_require__("../../../../../src/app/styles/list-styles.css")]
        }),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__services_vehicle_service__["a" /* VehicleService */],
            __WEBPACK_IMPORTED_MODULE_2__angular_router__["b" /* Router */]])
    ], VehicleListComponent);
    return VehicleListComponent;
}());



/***/ }),

/***/ "../../../../../src/environments/environment.prod.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
var environment = {
    production: true,
    APIURL: "http://localhost:63177",
    ADMINISTRATOR_ROLE: "ADMINISTRATOR",
    PORT_ROLE: "PORT_OPERATOR",
    TRANSPORTER_ROLE: "TRANSPORTER",
    YARD_ROLE: "YARD_OPERATOR",
    SALESMAN_ROLE: "SALESMAN",
    CAR_TYPE: "0",
    TRUCK_TYPE: "1",
    SUV_TYPE: "2",
    VAN_TYPE: "3",
    MINI_VAN_TYPE: "4",
    PORT_STAGE: "Puerto",
    TRANSPORT_STAGE: "Transporte",
    YARD_STAGE_PREFIX: "Patio",
    READY_FOR_SALE_STAGE: "Pronto para venta",
    PORT_STAGE_CODE: 0,
    TRANSPORT_STAGE_CODE: 1,
    YARD_STAGE_PREFIX_CODE: 2,
    READY_FOR_SALE_STAGE_CODE: 3,
    SOLD_STAGE_CODE: 4,
    STUCK_IN_PROCESS_CODE: 5
};


/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.
var environment = {
    production: false,
    APIURL: "http://localhost:63177",
    ADMINISTRATOR_ROLE: "ADMINISTRATOR",
    PORT_ROLE: "PORT_OPERATOR",
    TRANSPORTER_ROLE: "TRANSPORTER",
    YARD_ROLE: "YARD_OPERATOR",
    SALESMAN_ROLE: "SALESMAN",
    CAR_TYPE: "0",
    TRUCK_TYPE: "1",
    SUV_TYPE: "2",
    VAN_TYPE: "3",
    MINI_VAN_TYPE: "4",
    PORT_STAGE: "Puerto",
    TRANSPORT_STAGE: "Transporte",
    YARD_STAGE_PREFIX: "Patio",
    READY_FOR_SALE_STAGE: "Pronto para venta",
    PORT_STAGE_CODE: 0,
    TRANSPORT_STAGE_CODE: 1,
    YARD_STAGE_PREFIX_CODE: 2,
    READY_FOR_SALE_STAGE_CODE: 3,
    SOLD_STAGE_CODE: 4,
    STUCK_IN_PROCESS_CODE: 5
};


/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/esm5/core.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/esm5/platform-browser-dynamic.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_app_module__ = __webpack_require__("../../../../../src/app/app.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");




if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["_13" /* enableProdMode */])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_2__app_app_module__["a" /* AppModule */])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map