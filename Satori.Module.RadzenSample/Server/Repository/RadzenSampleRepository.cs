using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Satori.Module.RadzenSample.Models;

namespace Satori.Module.RadzenSample.Repository
{
    public class RadzenSampleRepository : IRadzenSampleRepository, ITransientService
    {
        private readonly RadzenSampleContext _db;

        public RadzenSampleRepository(RadzenSampleContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.RadzenSample> GetRadzenSamples(int ModuleId)
        {
            return _db.RadzenSample.Where(item => item.ModuleId == ModuleId);
        }

        public Models.RadzenSample GetRadzenSample(int RadzenSampleId)
        {
            return GetRadzenSample(RadzenSampleId, true);
        }

        public Models.RadzenSample GetRadzenSample(int RadzenSampleId, bool tracking)
        {
            if (tracking)
            {
                return _db.RadzenSample.Find(RadzenSampleId);
            }
            else
            {
                return _db.RadzenSample.AsNoTracking().FirstOrDefault(item => item.RadzenSampleId == RadzenSampleId);
            }
        }

        public Models.RadzenSample AddRadzenSample(Models.RadzenSample RadzenSample)
        {
            _db.RadzenSample.Add(RadzenSample);
            _db.SaveChanges();
            return RadzenSample;
        }

        public Models.RadzenSample UpdateRadzenSample(Models.RadzenSample RadzenSample)
        {
            _db.Entry(RadzenSample).State = EntityState.Modified;
            _db.SaveChanges();
            return RadzenSample;
        }

        public void DeleteRadzenSample(int RadzenSampleId)
        {
            Models.RadzenSample RadzenSample = _db.RadzenSample.Find(RadzenSampleId);
            _db.RadzenSample.Remove(RadzenSample);
            _db.SaveChanges();
        }
    }
}
