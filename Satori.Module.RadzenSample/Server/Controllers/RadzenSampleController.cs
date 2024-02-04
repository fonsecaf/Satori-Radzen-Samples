using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Satori.Module.RadzenSample.Repository;
using Oqtane.Controllers;
using System.Net;

namespace Satori.Module.RadzenSample.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class RadzenSampleController : ModuleControllerBase
    {
        private readonly IRadzenSampleRepository _RadzenSampleRepository;

        public RadzenSampleController(IRadzenSampleRepository RadzenSampleRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _RadzenSampleRepository = RadzenSampleRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.RadzenSample> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _RadzenSampleRepository.GetRadzenSamples(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized RadzenSample Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.RadzenSample Get(int id)
        {
            Models.RadzenSample RadzenSample = _RadzenSampleRepository.GetRadzenSample(id);
            if (RadzenSample != null && IsAuthorizedEntityId(EntityNames.Module, RadzenSample.ModuleId))
            {
                return RadzenSample;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized RadzenSample Get Attempt {RadzenSampleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.RadzenSample Post([FromBody] Models.RadzenSample RadzenSample)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, RadzenSample.ModuleId))
            {
                RadzenSample = _RadzenSampleRepository.AddRadzenSample(RadzenSample);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "RadzenSample Added {RadzenSample}", RadzenSample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized RadzenSample Post Attempt {RadzenSample}", RadzenSample);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                RadzenSample = null;
            }
            return RadzenSample;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.RadzenSample Put(int id, [FromBody] Models.RadzenSample RadzenSample)
        {
            if (ModelState.IsValid && RadzenSample.RadzenSampleId == id && IsAuthorizedEntityId(EntityNames.Module, RadzenSample.ModuleId) && _RadzenSampleRepository.GetRadzenSample(RadzenSample.RadzenSampleId, false) != null)
            {
                RadzenSample = _RadzenSampleRepository.UpdateRadzenSample(RadzenSample);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "RadzenSample Updated {RadzenSample}", RadzenSample);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized RadzenSample Put Attempt {RadzenSample}", RadzenSample);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                RadzenSample = null;
            }
            return RadzenSample;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.RadzenSample RadzenSample = _RadzenSampleRepository.GetRadzenSample(id);
            if (RadzenSample != null && IsAuthorizedEntityId(EntityNames.Module, RadzenSample.ModuleId))
            {
                _RadzenSampleRepository.DeleteRadzenSample(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "RadzenSample Deleted {RadzenSampleId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized RadzenSample Delete Attempt {RadzenSampleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
