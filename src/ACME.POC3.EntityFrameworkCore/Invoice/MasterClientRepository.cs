using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public class MasterClientRepository : EfCoreRepository<POC3DbContext, MasterClient, Guid>, IMasterClientRepository
{
    public MasterClientRepository(IDbContextProvider<POC3DbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<MasterClient>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}