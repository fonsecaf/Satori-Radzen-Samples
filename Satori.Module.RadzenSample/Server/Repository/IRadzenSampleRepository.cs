using System.Collections.Generic;
using Satori.Module.RadzenSample.Models;

namespace Satori.Module.RadzenSample.Repository
{
    public interface IRadzenSampleRepository
    {
        IEnumerable<Models.RadzenSample> GetRadzenSamples(int ModuleId);
        Models.RadzenSample GetRadzenSample(int RadzenSampleId);
        Models.RadzenSample GetRadzenSample(int RadzenSampleId, bool tracking);
        Models.RadzenSample AddRadzenSample(Models.RadzenSample RadzenSample);
        Models.RadzenSample UpdateRadzenSample(Models.RadzenSample RadzenSample);
        void DeleteRadzenSample(int RadzenSampleId);
    }
}
