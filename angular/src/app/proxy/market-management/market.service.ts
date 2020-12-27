import type { GetMarketsInput, MarketDto } from './dto/models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MarketService {
  apiName = 'Default';

  createUpdateMarketByMarketDto = (marketDto: MarketDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/market/updateMarket`,
      body: marketDto,
    },
    { apiName: this.apiName });

  deleteMarketById = (id: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/market/${id}/market`,
    },
    { apiName: this.apiName });

  getMarketsByInput = (input: GetMarketsInput) =>
    this.restService.request<any, PagedResultDto<MarketDto>>({
      method: 'GET',
      url: `/api/app/market/markets`,
      params: { tenantId: input.tenantId, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
