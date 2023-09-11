using System;
using Volo.Abp.Domain.Repositories;

namespace ACME.POC3.Invoice;

public interface IMasterClientRepository : IRepository<MasterClient, Guid>
{
}
