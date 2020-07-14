using FHIRRESTMapper.R4.Core.Features;
using System;
using System.Linq;

namespace FHIRRESTMapper.R4.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ob = new ResourceHydrant(@"C:\fhir_sample_data\sample1.json");

            var result=ob.GetAllResourceTypes();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
