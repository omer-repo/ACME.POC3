using System;
using Volo.Abp.Domain.Repositories;

namespace ACME.POC3.Invoice;

public interface IInvoiceLineRepository : IRepository<InvoiceLine, Guid>
{
}
