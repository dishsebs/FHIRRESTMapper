using System;
using System.Collections.Generic;
using System.Text;

namespace FHIRRESTMapper.R4.Core.Models
{
   public class FhirResource
    {
        public string Name { get; set; }
        public bool HasChildrens { get; set; }

        public IEnumerable<FhirResource> Childrens { get; set; }
    }
}
