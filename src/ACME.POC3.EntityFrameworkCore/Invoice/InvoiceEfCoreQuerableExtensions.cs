using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public static class InvoiceEfCoreQueryableExtensions
{
    public static IQueryable<Invoice> IncludeDetails(this IQueryable<Invoice> queryable, bool include = true)
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
