using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FHIRRESTMapper.R4.Core.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FHIRRESTMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FHIRResourceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var ob = new ResourceHydrant(@"C:\fhir_sample_data\sample1.json");
            return ob.GetAllResourceTypes();
        }
    }
}
