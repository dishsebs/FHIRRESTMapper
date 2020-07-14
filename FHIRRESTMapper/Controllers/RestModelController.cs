using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace FHIRRESTMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestModelController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            try
            {
                using StreamReader sr = new StreamReader(@"C:\REST_Model_Samples\RestSample.json");
                string jsonModel = sr.ReadToEnd();
                JSchema jSchema = JSchema.Parse(jsonModel);
                JObject jObject = JObject.Parse(jsonModel);
                //Request.
                //var returnObj = jObject.IsValid(jSchema) ? jsonModel : string.Empty;
                return jObject.IsValid(jSchema) ? jsonModel : string.Empty;
                //return jObject.IsValid(jSchema) ? Ok(JsonConvert.DeserializeObject(jsonModel)) : BadRequest(;
                //return Ok(JsonConvert.DeserializeObject(jsonModel));
                //return (JsonResult)JsonConvert.DeserializeObject(jsonModel);
            }
            catch (Exception e)
            {
                //return BadRequest(e.Message);
                return string.Empty;
            }
        }
    }
}
