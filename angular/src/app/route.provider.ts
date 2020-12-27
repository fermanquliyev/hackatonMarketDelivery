import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application
      },
      {
        path: '/store',
        name: '::Menu:Store',
        iconClass: 'fas fa-store',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'Market.GetMarkets'
      },
      {
        path: '/items',
        name: '::Menu:Items',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
        requiredPolicy: 'Market.GetMarkets'
      },
      {
        path: '/orders',
        name: '::Menu:Orders',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
        requiredPolicy: 'Market.GetMarkets'
      },
      {
        path: '/markets',
        name: '::Menu:Markets',
        parentName: '::Menu:Store',
        layout: eLayoutType.application,
        requiredPolicy: 'Market.GetMarkets'
      },
    ]);
  };
}
