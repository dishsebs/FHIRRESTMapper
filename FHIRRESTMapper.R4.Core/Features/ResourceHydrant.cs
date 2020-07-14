using FHIRRESTMapper.R4.Core.Models;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath;
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

        public IEnumerable<FhirResource> GetAllAttrubutes(string resourceType)
        {
            var returnList = new List<FhirResource>();
            var result = ParseBundle();
            var filterdType = result.ToTypedElement().Select("Bundle.entry.resource")
                .Where(x => string.Equals(x.InstanceType, resourceType, System.StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            returnList = FileChildrenChilds(filterdType.Children().ToList());

            //foreach (var resource in filterdType.Children().ToList())
            //{
            //    var currentResource = new FhirResource();
            //    currentResource.Name = resource.Name;

            //    var childrenChilds = resource.Children().ToList();
            //    if (childrenChilds.Count > 0)
            //    {
            //        currentResource.Childrens = FileChildrenChilds(childrenChilds);
            //        currentResource.HasChildrens = true;
            //    }
            //    returnList.Add(currentResource);
            //}

            return returnList;
        }

        private static List<FhirResource> FileChildrenChilds(List<ITypedElement> resource)
        {
            var returnList = new List<FhirResource>();
            foreach (ITypedElement child in resource)
            {
                var currentResource = new FhirResource();
                currentResource.Name = child.Name;
                var childrenchilds = child.Children().ToList();
                if (childrenchilds.Count > 0)
                {
                    currentResource.Childrens = FileChildrenChilds(childrenchilds);
                    currentResource.HasChildrens = true;
                }

                returnList.Add(currentResource);
            }

            return returnList;
        }
    }
}