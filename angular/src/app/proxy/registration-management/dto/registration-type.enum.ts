import { mapEnumToOptions } from '@abp/ng.core';

export enum RegistrationType {
  Customer = 1,
  Deliverer = 2,
}

export const registrationTypeOptions = mapEnumToOptions(RegistrationType);
