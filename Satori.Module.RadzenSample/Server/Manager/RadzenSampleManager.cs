using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using Satori.Module.RadzenSample.Repository;

namespace Satori.Module.RadzenSample.Manager
{
    public class RadzenSampleManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IRadzenSampleRepository _RadzenSampleRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public RadzenSampleManager(IRadzenSampleRepository RadzenSampleRepository, IDBContextDependencies DBContextDependencies)
        {
            _RadzenSampleRepository = RadzenSampleRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new RadzenSampleContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new RadzenSampleContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.RadzenSample> RadzenSamples = _RadzenSampleRepository.GetRadzenSamples(module.ModuleId).ToList();
            if (RadzenSamples != null)
            {
                content = JsonSerializer.Serialize(RadzenSamples);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.RadzenSample> RadzenSamples = null;
            if (!string.IsNullOrEmpty(content))
            {
                RadzenSamples = JsonSerializer.Deserialize<List<Models.RadzenSample>>(content);
            }
            if (RadzenSamples != null)
            {
                foreach(var RadzenSample in RadzenSamples)
                {
                    _RadzenSampleRepository.AddRadzenSample(new Models.RadzenSample { ModuleId = module.ModuleId, Name = RadzenSample.Name });
                }
            }
        }
    }
}
