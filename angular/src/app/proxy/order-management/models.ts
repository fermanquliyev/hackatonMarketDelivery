import type { PagedResultRequestDto } from '@abp/ng.core';
import type { OrderStatus } from './order-status.enum';

export interface CreateOrderInput {
  orderLines: CreateOrderLineInput[];
  deliveryAdressInfo: DeliveryAdressInfoDto;
  tenantId: string;
}

export interface CreateOrderLineInput {
  itemId: number;
  price: number;
  quantity: number;
}

export interface DeliveryAdressInfoDto {
  city: string;
  address: string;
  latitude?: number;
  longitude?: number;
}

export interface GetOrdersInput extends PagedResultRequestDto {
  tenantId?: string;
}

export interface OrderDto {
  id: string;
  orderStatus: OrderStatus;
  orderStatusDescription: string;
  tenantId: string;
  creationTime: string;
  extraProperties: Record<string, object>;
  distance: number;
}

export interface PositionDto {
  latitude: number;
  longitude: number;
}
