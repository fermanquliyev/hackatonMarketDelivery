import { mapEnumToOptions } from '@abp/ng.core';

export enum OrderStatus {
  Initial = 0,
  Accepted = 1,
  Prepearing = 2,
  WaitingForDelivery = 3,
  DelivererAccepted = 4,
  OnTheWay = 5,
  Arrived = 6,
  Delivered = 7,
  Ignored = 8,
}

export const orderStatusOptions = mapEnumToOptions(OrderStatus);
