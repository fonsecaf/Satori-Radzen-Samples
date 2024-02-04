using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace Satori.Module.RadzenSample.Repository
{
    public class RadzenSampleContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.RadzenSample> RadzenSample { get; set; }

        public RadzenSampleContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
