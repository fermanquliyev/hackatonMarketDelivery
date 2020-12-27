import type { PagedResultRequestDto } from '@abp/ng.core';

export interface CategoryDto {
  id: number;
  name: string;
  description: string;
}

export interface GetItemsInput extends PagedResultRequestDto {
  searchKeyword: string;
  categoryId?: number;
  tenantId?: string;
}

export interface ItemDto {
  id: number;
  name: string;
  code: string;
  description: string;
  barcode: string;
  price: number;
  oldPrice?: number;
  categoryId: number;
  photoUrl: string;
  tenantId: string;
  creationTime: string;
  stockCount: number;
  extraProperties: Record<string, object>;
}

export interface SetItemStockInput {
  itemId: number;
  stockCount: number;
}
