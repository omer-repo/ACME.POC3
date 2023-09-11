using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ACME.POC3.Data;

/* This is used if database provider does't define
 * IPOC3DbSchemaMigrator implementation.
 */
public class NullPOC3DbSchemaMigrator : IPOC3DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
