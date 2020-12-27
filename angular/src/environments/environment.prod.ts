import { Config } from '@abp/ng.core';

const baseUrl = 'https://delivery.prostudy.club';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Delivery',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://delivery.prostudy-core.club',
    redirectUri: baseUrl,
    clientId: 'Delivery_App',
    responseType: 'code',
    scope: 'offline_access Delivery',
  },
  apis: {
    default: {
      url: 'https://delivery.prostudy-core.club',
      rootNamespace: 'Demirqol.Delivery',
    },
  },
} as Config.Environment;
