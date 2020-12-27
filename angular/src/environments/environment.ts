import { Config } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Delivery',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44396',
    redirectUri: baseUrl,
    clientId: 'Delivery_App',
    responseType: 'code',
    scope: 'offline_access Delivery',
  },
  apis: {
    default: {
      url: 'https://localhost:44396',
      rootNamespace: 'Demirqol.Delivery',
    },
  },
} as Config.Environment;
