using Oqtane.Models;
using Oqtane.Modules;

namespace Satori.Module.RadzenSample
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "RadzenSample",
            Description = "Sample to use Radzen",
            Version = "1.0.0",
            ServerManagerType = "Satori.Module.RadzenSample.Manager.RadzenSampleManager, Satori.Module.RadzenSample.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Satori.Module.RadzenSample.Shared.Oqtane,Radzen.Blazor",
            PackageName = "Satori.Module.RadzenSample" 
        };
    }
}
