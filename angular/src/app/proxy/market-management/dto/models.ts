import type { PagedResultRequestDto } from '@abp/ng.core';

export interface GetMarketsInput extends PagedResultRequestDto {
  tenantId?: string;
}

export interface MarketDto {
  id: number;
  name: string;
  address: string;
  latitude?: number;
  longitude?: number;
  isDefault: boolean;
  tenantId: string;
}
