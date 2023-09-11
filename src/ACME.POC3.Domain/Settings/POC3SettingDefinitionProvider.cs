using Volo.Abp.Settings;

namespace ACME.POC3.Settings;

public class POC3SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(POC3Settings.MySetting1));
    }
}
