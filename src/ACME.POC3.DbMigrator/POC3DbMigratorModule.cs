using ACME.POC3.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ACME.POC3.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(POC3EntityFrameworkCoreModule),
    typeof(POC3ApplicationContractsModule)
    )]
public class POC3DbMigratorModule : AbpModule
{
}
