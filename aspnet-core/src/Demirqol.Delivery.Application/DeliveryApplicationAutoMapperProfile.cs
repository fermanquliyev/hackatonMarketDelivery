using AutoMapper;
using Demirqol.Delivery.ItemManagement;
using Demirqol.Delivery.ItemManagement.Dto;
using Demirqol.Delivery.MarketManagement;
using Demirqol.Delivery.MarketManagement.Dto;

namespace Demirqol.Delivery
{
    public class DeliveryApplicationAutoMapperProfile : Profile
    {
        public DeliveryApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Market, MarketDto>();
            CreateMap<MarketDto, Market>();
        }
    }
}
