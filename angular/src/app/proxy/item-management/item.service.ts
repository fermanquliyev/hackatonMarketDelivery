import type { CategoryDto, GetItemsInput, ItemDto, SetItemStockInput } from './dto/models';
import { RestService } from '@abp/ng.core';
import type { ListResultDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ItemService {
  apiName = 'Default';

  createUpdateItemByItemDto = (itemDto: ItemDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/item/updateItem`,
      body: itemDto,
    },
    { apiName: this.apiName });

  deleteByItemId = (itemId: number) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/item`,
      params: { itemId: itemId },
    },
    { apiName: this.apiName });

  getCategories = () =>
    this.restService.request<any, ListResultDto<CategoryDto>>({
      method: 'GET',
      url: `/api/app/item/categories`,
    },
    { apiName: this.apiName });

  getItemsByInput = (input: GetItemsInput) =>
    this.restService.request<any, PagedResultDto<ItemDto>>({
      method: 'GET',
      url: `/api/app/item/items`,
      params: { searchKeyword: input.searchKeyword, categoryId: input.categoryId, tenantId: input.tenantId, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  setItemStockByInput = (input: SetItemStockInput) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/item/setItemStock`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
