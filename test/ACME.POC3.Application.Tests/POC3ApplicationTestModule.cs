using Volo.Abp.Modularity;

namespace ACME.POC3;

[DependsOn(
    typeof(POC3ApplicationModule),
    typeof(POC3DomainTestModule)
    )]
public class POC3ApplicationTestModule : AbpModule
{

}
