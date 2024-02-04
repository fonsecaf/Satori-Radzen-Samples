using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Satori.Module.RadzenSample.Models;

namespace Satori.Module.RadzenSample.Services
{
    public class RadzenSampleService : ServiceBase, IRadzenSampleService, IService
    {
        public RadzenSampleService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("RadzenSample");

        public async Task<List<Models.RadzenSample>> GetRadzenSamplesAsync(int ModuleId)
        {
            List<Models.RadzenSample> RadzenSamples = await GetJsonAsync<List<Models.RadzenSample>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.RadzenSample>().ToList());
            return RadzenSamples.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.RadzenSample> GetRadzenSampleAsync(int RadzenSampleId, int ModuleId)
        {
            return await GetJsonAsync<Models.RadzenSample>(CreateAuthorizationPolicyUrl($"{Apiurl}/{RadzenSampleId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.RadzenSample> AddRadzenSampleAsync(Models.RadzenSample RadzenSample)
        {
            return await PostJsonAsync<Models.RadzenSample>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, RadzenSample.ModuleId), RadzenSample);
        }

        public async Task<Models.RadzenSample> UpdateRadzenSampleAsync(Models.RadzenSample RadzenSample)
        {
            return await PutJsonAsync<Models.RadzenSample>(CreateAuthorizationPolicyUrl($"{Apiurl}/{RadzenSample.RadzenSampleId}", EntityNames.Module, RadzenSample.ModuleId), RadzenSample);
        }

        public async Task DeleteRadzenSampleAsync(int RadzenSampleId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{RadzenSampleId}", EntityNames.Module, ModuleId));
        }
    }
}
