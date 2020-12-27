using Demirqol.Delivery.MarketManagement.Dto;
using Demirqol.Delivery.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Demirqol.Delivery.MarketManagement
{
    [Authorize]
    public class MarketAppService : DeliveryAppService
    {
        private readonly IRepository<Market> _marketRepository;

        public MarketAppService(IRepository<Market> marketRepository)
        {
            this._marketRepository = marketRepository;
        }

        [Authorize(MarketPermissions.GetMarkets)]
        public async Task<PagedResultDto<MarketDto>> GetMarkets(GetMarketsInput input)
        {
            var markets = _marketRepository.WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId).AsQueryable();
            var totalCount = await AsyncExecuter.CountAsync(markets);
            var items = await AsyncExecuter.ToListAsync(markets.OrderByDescending(x => x.CreationTime).PageBy(input));
            return new PagedResultDto<MarketDto>(totalCount, ObjectMapper.Map<List<Market>, List<MarketDto>>(items));
        }

        [Authorize(MarketPermissions.CreateMarket)]
        public async Task CreateUpdateMarket(MarketDto marketDto)
        {
            if (marketDto.Id > 0)
            {
                var existsItem = await _marketRepository.FindAsync(x => x.Id == marketDto.Id);
                ObjectMapper.Map(marketDto, existsItem);
                existsItem.TenantId = CurrentTenant.Id.Value;
            }
            else
            {
                var item = ObjectMapper.Map<MarketDto, Market>(marketDto);
                item.TenantId = CurrentTenant.Id.Value;
                await _marketRepository.InsertAsync(item);
            }
        }
        [Authorize(MarketPermissions.DeleteMarket)]
        public async Task DeleteMarket(int id)
        {
            var existsItem = await _marketRepository.FindAsync(x => x.Id == id);
            if (existsItem != null)
            {
                await _marketRepository.DeleteAsync(existsItem);
            }
        }
    }
}
