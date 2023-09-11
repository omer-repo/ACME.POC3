using ACME.POC3.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ACME.POC3.Blazor;

public abstract class POC3ComponentBase : AbpComponentBase
{
    protected POC3ComponentBase()
    {
        LocalizationResource = typeof(POC3Resource);
    }
}
