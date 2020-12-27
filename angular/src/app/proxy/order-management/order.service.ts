import type { CreateOrderInput, GetOrdersInput, OrderDto, PositionDto } from './models';
import type { OrderStatus } from './order-status.enum';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  apiName = 'Default';

  confirmOrderDeliveredById = (id: string) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/order/${id}/confirmOrderDelivered`,
    },
    { apiName: this.apiName });

  createOrderByOrderInput = (orderInput: CreateOrderInput) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: `/api/app/order/order`,
      body: orderInput,
    },
    { apiName: this.apiName });

  getMyOrdersByInput = (input: GetOrdersInput) =>
    this.restService.request<any, PagedResultDto<OrderDto>>({
      method: 'GET',
      url: `/api/app/order/myOrders`,
      params: { tenantId: input.tenantId, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getOrdersByInput = (input: GetOrdersInput) =>
    this.restService.request<any, PagedResultDto<OrderDto>>({
      method: 'GET',
      url: `/api/app/order/orders`,
      params: { tenantId: input.tenantId, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  getOrdersNearbyByPositionDto = (positionDto: PositionDto) =>
    this.restService.request<any, PagedResultDto<OrderDto>>({
      method: 'GET',
      url: `/api/app/order/ordersNearby`,
      params: { latitude: positionDto.latitude, longitude: positionDto.longitude },
    },
    { apiName: this.apiName });

  giveOrderForDeliveringByIdAndDeliveryUserName = (id: string, deliveryUserName: string) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/order/${id}/giveOrderForDelivering`,
      params: { deliveryUserName: deliveryUserName },
    },
    { apiName: this.apiName });

  ignoreOrderByIdAndNote = (id: string, note: string) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/order/${id}/ignoreOrder`,
      params: { note: note },
    },
    { apiName: this.apiName });

  updateOrderDeliveryStatusById = (id: string) =>
    this.restService.request<any, OrderStatus>({
      method: 'PUT',
      url: `/api/app/order/${id}/orderDeliveryStatus`,
    },
    { apiName: this.apiName });

  updateOrderStatusById = (id: string) =>
    this.restService.request<any, OrderStatus>({
      method: 'PUT',
      url: `/api/app/order/${id}/orderStatus`,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
