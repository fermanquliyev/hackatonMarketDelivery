using AutoMapper.QueryableExtensions;
using Demirqol.Delivery.ItemManagement.Dto;
using Demirqol.Delivery.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Demirqol.Delivery.ItemManagement
{
    [Authorize]
    public class ItemAppService : DeliveryAppService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ItemAppService(IRepository<Item> itemRepository,
            IRepository<Category> categoryRepository)
        {
            this._itemRepository = itemRepository;
            this._categoryRepository = categoryRepository;
        }
        public async Task CreateUpdateItem(ItemDto itemDto)
        {
            if (itemDto.Id > 0)
            {
                var existsItem = await _itemRepository.FindAsync(x => x.Id == itemDto.Id);
                ObjectMapper.Map(itemDto, existsItem);
                existsItem.TenantId = CurrentTenant.Id.Value;
            }
            else
            {
                var item = ObjectMapper.Map<ItemDto, Item>(itemDto);
                item.TenantId = CurrentTenant.Id.Value;
                await _itemRepository.InsertAsync(item);
            }
        }
        public async Task SetItemStock(SetItemStockInput input)
        {
            var existsItem = await _itemRepository.FindAsync(x => x.Id == input.ItemId);
            if (existsItem != null)
            {
                existsItem.StockCount = input.StockCount;
                existsItem.OnStock = input.StockCount > 0;
            }
        }
        public async Task Delete(int itemId)
        {
            var existsItem = await _itemRepository.FindAsync(x => x.Id == itemId);
            if (existsItem != null)
            {
                await _itemRepository.DeleteAsync(existsItem);
            }
        }
        public async Task<PagedResultDto<ItemDto>> GetItems(GetItemsInput input)
        {
            var query = _itemRepository.WhereIf(input.CategoryId.HasValue, x => x.CategoryId == input.CategoryId)
                .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId)
                .WhereIf(!input.SearchKeyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.SearchKeyword))
                .OrderByDescending(x => x.CreationTime);
            var totalCount = await AsyncExecuter.CountAsync(query);
            var result = await AsyncExecuter.ToListAsync(query.PageBy(input));
            return new PagedResultDto<ItemDto>(totalCount, ObjectMapper.Map<List<Item>, List<ItemDto>>(result));
        }

        public async Task<ListResultDto<CategoryDto>> GetCategories()
        {
            var result = await _categoryRepository.GetListAsync();
            return new ListResultDto<CategoryDto>(ObjectMapper.Map<List<Category>, List<CategoryDto>>(result));
        }
    }
}
