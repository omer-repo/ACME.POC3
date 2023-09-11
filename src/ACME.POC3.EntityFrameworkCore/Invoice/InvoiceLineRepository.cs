using System;
using System.Linq;
using System.Threading.Tasks;
using ACME.POC3.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public class InvoiceLineRepository : EfCoreRepository<POC3DbContext, InvoiceLine, Guid>, IInvoiceLineRepository
{
    public InvoiceLineRepository(IDbContextProvider<POC3DbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<InvoiceLine>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}