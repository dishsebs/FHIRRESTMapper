using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FHIRRESTMapper.R4.Core.Features
{
    public class ResourceHydrant
    {
        private string _fhirInput = string.Empty;

        public ResourceHydrant(string fhirInput)
        {
            this._fhirInput = fhirInput;
        }

        public IEnumerable<string> GetAllResourceTypes()
        {
            var result = ParseBundle();

            var ResourceTypeLst = result.Entry.Select(x => x.Resource.TypeName)
                                              .ToList()
                                              .Distinct();
            return ResourceTypeLst;
        }

        private Bundle ParseBundle()
        {
            using (StreamReader sr = new StreamReader(_fhirInput))
            {
                string content = string.Empty;
                content = sr.ReadToEnd();
                var parser = new FhirJsonParser();
                Bundle result = parser.Parse<Bundle>(content);
                return result;
            }
        }

        public IEnumerable<Resource> GetAllAttrubutes(string resourceType)
        {
            var returnList = new List<Resource>();

            return returnList;
        }
    }
}