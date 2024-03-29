// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
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
