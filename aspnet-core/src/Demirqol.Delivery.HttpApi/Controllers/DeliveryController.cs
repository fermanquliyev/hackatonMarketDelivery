using Demirqol.Delivery.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Demirqol.Delivery.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DeliveryController : AbpController
    {
        protected DeliveryController()
        {
            LocalizationResource = typeof(DeliveryResource);
        }
    }
}