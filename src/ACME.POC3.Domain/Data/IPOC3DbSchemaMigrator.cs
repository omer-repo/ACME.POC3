using System.Threading.Tasks;

namespace ACME.POC3.Data;

public interface IPOC3DbSchemaMigrator
{
    Task MigrateAsync();
}
