using System.Collections.Generic;

namespace FHIRRESTMapper.R4.Core.Models
{
    public class FhirResource
    {
        public FhirResource()
        {
            this.Childrens = new List<FhirResource>();
        }

        public string Name { get; set; }
        public bool HasChildrens { get; set; }

        public IEnumerable<FhirResource> Childrens { get; set; }
    }
}