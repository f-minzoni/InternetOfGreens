using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetOfGreens.Domain;

namespace InternetOfGreens
{
    public class SampleModule : NancyModule
    {
        public SampleModule(ISampleService svc)
            : base("/samples")
        {
            Get["/"] = x =>
            {
                return Response.AsJson<object>(svc.GetAll());
            };

            Get["/sensor/{sensorId}"] = parameters =>
            {
                List<Sample> samples = svc.GetBySensor(parameters.sensorId);
                return Response.AsJson<object>(samples);
            };
        }

    }
}
