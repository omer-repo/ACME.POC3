using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ACME.POC3.Invoice;

public static class MasterClientEfCoreQueryableExtensions
{
    public static IQueryable<MasterClient> IncludeDetails(this IQueryable<MasterClient> queryable, bool include = true)
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
