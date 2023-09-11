using ACME.POC3.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ACME.POC3;

[DependsOn(
    typeof(POC3EntityFrameworkCoreTestModule)
    )]
public class POC3DomainTestModule : AbpModule
{

}
