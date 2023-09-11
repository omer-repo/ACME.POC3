using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public static class InvoiceLineEfCoreQueryableExtensions
{
    public static IQueryable<InvoiceLine> IncludeDetails(this IQueryable<InvoiceLine> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
