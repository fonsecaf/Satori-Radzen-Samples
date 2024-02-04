using System.Collections.Generic;
using System.Threading.Tasks;
using Satori.Module.RadzenSample.Models;

namespace Satori.Module.RadzenSample.Services
{
    public interface IRadzenSampleService 
    {
        Task<List<Models.RadzenSample>> GetRadzenSamplesAsync(int ModuleId);

        Task<Models.RadzenSample> GetRadzenSampleAsync(int RadzenSampleId, int ModuleId);

        Task<Models.RadzenSample> AddRadzenSampleAsync(Models.RadzenSample RadzenSample);

        Task<Models.RadzenSample> UpdateRadzenSampleAsync(Models.RadzenSample RadzenSample);

        Task DeleteRadzenSampleAsync(int RadzenSampleId, int ModuleId);
    }
}
