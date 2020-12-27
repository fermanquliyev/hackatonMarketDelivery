using Demirqol.Delivery.ItemManagement;
using Demirqol.Delivery.MarketManagement;
using Demirqol.Delivery.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Demirqol.Delivery.OrderManagement
{
    [Authorize]
    public class OrderAppService : DeliveryAppService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IRepository<Market> _marketRepository;
        private readonly IRepository<Item> _itemRepository;

        public OrderAppService(IRepository<Order> orderRepository,
            IdentityUserManager identityUserManager,
            IRepository<Market> marketRepository,
            IRepository<Item> itemRepository)
        {
            _orderRepository = orderRepository;
            this._identityUserManager = identityUserManager;
            _marketRepository = marketRepository;
            _itemRepository = itemRepository;
        }

        [Authorize(OrderPermissions.Create)]
        public async Task<Guid> CreateOrder(CreateOrderInput orderInput)
        {
            var order = new Order(GuidGenerator.Create())
            {
                CreatorId = CurrentUser.Id,
                TenantId = orderInput.TenantId,
                OrderStatus = OrderStatus.Initial,
                OrderStatusDescription = "Sifarişiniz başlanğıc mərhələdədir"
            };

            var chechkedOrderLines = await CheckOrderAsync(orderInput);
            order.SetProperty("OrderLines", chechkedOrderLines);
            order.SetProperty("DeliveryAdressInfo", orderInput.DeliveryAdressInfo);
            order.SetProperty("TotalQuantity", orderInput.OrderLines.Sum(x => x.Quantity));
            order.SetProperty("TotalSum", orderInput.OrderLines.Sum(x => x.Quantity * x.Price));
            var defaultMarket = await AsyncExecuter.FirstOrDefaultAsync(_marketRepository.Where(x => x.TenantId == orderInput.TenantId).OrderByDescending(x => x.IsDefault));
            if (defaultMarket != null)
            {
                order.MarketId = defaultMarket.Id;
            }
            order.OrderLines = orderInput.OrderLines.Select(x => new OrderLine
            {
                ItemId = x.ItemId,
                OrderId = order.Id,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList();
            await _orderRepository.InsertAsync(order);
            return order.Id;
        }
        public async Task<PagedResultDto<OrderDto>> GetOrders(GetOrdersInput input)
        {
            var query = _orderRepository
                  .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId).Select(x => new OrderDto
                  {
                      Id = x.Id,
                      OrderStatusDescription = x.OrderStatusDescription,
                      ExtraProperties = x.ExtraProperties,
                      OrderStatus = x.OrderStatus,
                      TenantId = x.TenantId,
                      CreationTime = x.CreationTime,
                      MarketId = x.MarketId
                  });
            var totalCount = await AsyncExecuter.CountAsync(query);
            var items = await AsyncExecuter.ToListAsync(query.OrderByDescending(x => x.CreationTime).PageBy(input));
            return new PagedResultDto<OrderDto>(totalCount, items);
        }
        [Authorize(UserTypePermissions.Deliverer)]
        public async Task<PagedResultDto<OrderDto>> GetOrdersNearby(PositionDto positionDto)
        {
            var markets = _marketRepository
                .Select(x => new { x.Id, Distance = Math.Abs(x.Latitude.Value - positionDto.Latitude) + Math.Abs(x.Longitude.Value - positionDto.Longitude) });
            var query = from order in _orderRepository.Where(x => x.OrderStatus == OrderStatus.WaitingForDelivery)
                        join market in markets.Where(x => x.Distance < 0.1) on order.MarketId equals market.Id
                        select new OrderDto
                        {
                            Id = order.Id,
                            OrderStatusDescription = order.OrderStatusDescription,
                            ExtraProperties = order.ExtraProperties,
                            OrderStatus = order.OrderStatus,
                            TenantId = order.TenantId,
                            CreationTime = order.CreationTime,
                            Distance = market.Distance,
                            MarketId = order.MarketId
                        };
            var items = await AsyncExecuter.ToListAsync(query.OrderBy(x => x.Distance));
            return new PagedResultDto<OrderDto>(items.Count, items);
        }
        [Authorize(OrderPermissions.UpdateOrderStatus)]
        public async Task GiveOrderForDelivering(Guid id, string deliveryUserName)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id && x.OrderStatus == OrderStatus.WaitingForDelivery);
            var deliveryUser = await _identityUserManager.FindByNameAsync(deliveryUserName);
            if (deliveryUser == null)
            {
                throw new UserFriendlyException("Belə istifadəçi tapılmadı: " + deliveryUserName);
            }
            order.DeliveryUserId = deliveryUser.Id;
            order.OrderStatus = OrderStatus.DelivererAccepted;
            order.OrderStatusDescription = "Sifarişiniz kuryerə verildi";
            order.SetProperty("DeliveryUser", new
            {
                deliveryUser.Name,
                deliveryUser.Surname,
                deliveryUser.PhoneNumber,
                deliveryUser.UserName
            });
        }
        [Authorize(UserTypePermissions.Deliverer)]
        public async Task GetOrderForDelivering(Guid id)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id && x.OrderStatus == OrderStatus.WaitingForDelivery);
            var deliveryUser = await _identityUserManager.FindByIdAsync(CurrentUser.Id.ToString());
            order.DeliveryUserId = deliveryUser.Id;
            order.OrderStatus = OrderStatus.DelivererAccepted;
            order.OrderStatusDescription = "Sifarişiniz kuryerə verildi";
            order.SetProperty("DeliveryUser", new
            {
                deliveryUser.Name,
                deliveryUser.Surname,
                deliveryUser.PhoneNumber,
                deliveryUser.UserName
            });
        }
        [Authorize(OrderPermissions.UpdateOrderStatus)]
        public async Task<OrderStatus> UpdateOrderStatus(Guid id)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id);
            switch (order.OrderStatus)
            {
                case OrderStatus.Initial:
                    order.OrderStatus = OrderStatus.Accepted;
                    order.OrderStatusDescription = "Sifarişiniz qəbul olunub";
                    break;
                case OrderStatus.Accepted:
                    order.OrderStatus = OrderStatus.Prepearing;
                    order.OrderStatusDescription = "Sifarişiniz hazirlanir";
                    break;
                case OrderStatus.Prepearing:
                    order.OrderStatus = OrderStatus.WaitingForDelivery;
                    order.OrderStatusDescription = "Sifarişiniz kuryer gözləyir";
                    break;
                default:
                    break;
            }
            return order.OrderStatus;
        }
        [Authorize(OrderPermissions.UpdateDeliveryStatus)]
        public async Task<OrderStatus> UpdateOrderDeliveryStatus(Guid id)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id);
            switch (order.OrderStatus)
            {
                case OrderStatus.DelivererAccepted:
                    order.OrderStatus = OrderStatus.OnTheWay;
                    order.OrderStatusDescription = "Sifarişiniz yoldadır";
                    break;
                case OrderStatus.OnTheWay:
                    order.OrderStatus = OrderStatus.Arrived;
                    order.OrderStatusDescription = "Sifarişiniz ünvana çatıb";
                    break;
                default:
                    break;
            }
            return order.OrderStatus;
        }
        public async Task IgnoreOrder(Guid id, string note)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id && (x.TenantId == CurrentTenant.Id || x.DeliveryUserId == CurrentUser.Id));
            if (order != null)
            {
                order.OrderStatus = OrderStatus.Ignored;
                order.OrderStatusDescription = note;
            }
        }

        [Authorize(UserTypePermissions.Customer)]
        public async Task ConfirmOrderDelivered(Guid id)
        {
            var order = await _orderRepository.FindAsync(x => x.Id == id && x.CreatorId == CurrentUser.Id && x.OrderStatus == OrderStatus.Arrived);
            order.OrderStatus = OrderStatus.Delivered;
            order.SetProperty("DeliveryTime", Clock.Now);
        }
        [Authorize(UserTypePermissions.Customer)]
        public async Task<PagedResultDto<OrderDto>> GetMyOrders(GetOrdersInput input)
        {
            var query = _orderRepository.Where(x => x.CreatorId == CurrentUser.Id)
                  .WhereIf(input.TenantId.HasValue, x => x.TenantId == input.TenantId).Select(x => new OrderDto
                  {
                      Id = x.Id,
                      OrderStatusDescription = x.OrderStatusDescription,
                      ExtraProperties = x.ExtraProperties,
                      OrderStatus = x.OrderStatus,
                      TenantId = x.TenantId,
                      CreationTime = x.CreationTime
                  });
            var totalCount = await AsyncExecuter.CountAsync(query);
            var items = await AsyncExecuter.ToListAsync(query.OrderByDescending(x => x.CreationTime).PageBy(input));
            return new PagedResultDto<OrderDto>(totalCount, items);
        }

        private async Task<List<OrderLineDto>> CheckOrderAsync(CreateOrderInput orderInput)
        {
            var output = new List<OrderLineDto>();
            var itemIds = orderInput.OrderLines.Select(x => x.ItemId).ToList();
            var items = await AsyncExecuter.ToListAsync(_itemRepository.Where(x => itemIds.Contains(x.Id) && x.TenantId == orderInput.TenantId));
            foreach (var ol in orderInput.OrderLines)
            {
                var item = items.FirstOrDefault(x => x.Id == ol.ItemId);
                if (item == null)
                {
                    throw new UserFriendlyException($"Məhsul tapılmadı {item.Name}");
                }
                else if (item.Price != ol.Price)
                {
                    throw new UserFriendlyException($"Məhsulun qiyməti dəyişib {item.Name}");
                }
                else if (item.StockCount < ol.Quantity)
                {
                    throw new UserFriendlyException($"Məhsulun stokdakı sayı azdır {item.Name}");
                }
                else
                {
                    item.StockCount = item.StockCount - ol.Quantity;
                    output.Add(new OrderLineDto
                    {
                        Name = item.Name,
                        Code = item.Code,
                        Description = item.Description,
                        ItemId = ol.ItemId,
                        PhotoUrl = item.PhotoUrl,
                        Price = item.Price,
                        Quantity = ol.Quantity
                    });
                }
            }
            return output;
        }
    }
}
