using Volo.Abp.Settings;

namespace Demirqol.Delivery.Settings
{
    public class DeliverySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DeliverySettings.MySetting1));
        }
    }
}
