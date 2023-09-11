using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public class InvoiceRepository : EfCoreRepository<POC3DbContext, Invoice, Guid>, IInvoiceRepository
{
    public InvoiceRepository(IDbContextProvider<POC3DbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Invoice>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}