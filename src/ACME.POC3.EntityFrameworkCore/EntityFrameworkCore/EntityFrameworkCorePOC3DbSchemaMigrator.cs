using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ACME.POC3.Data;
using Volo.Abp.DependencyInjection;

namespace ACME.POC3.EntityFrameworkCore;

public class EntityFrameworkCorePOC3DbSchemaMigrator
    : IPOC3DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePOC3DbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the POC3DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<POC3DbContext>()
            .Database
            .MigrateAsync();
    }
}
