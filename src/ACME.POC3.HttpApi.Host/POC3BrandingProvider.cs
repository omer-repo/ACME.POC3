using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ACME.POC3;

[Dependency(ReplaceServices = true)]
public class POC3BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "POC3";
}
