using System;
using System.Collections.Generic;
using System.Text;
using Demirqol.Delivery.Localization;
using Volo.Abp.Application.Services;

namespace Demirqol.Delivery
{
    /* Inherit your application services from this class.
     */
    public abstract class DeliveryAppService : ApplicationService
    {
        protected DeliveryAppService()
        {
            LocalizationResource = typeof(DeliveryResource);
        }
    }
}
