using Nancy;
using Nancy.ModelBinding;
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

            Post["/"] = _ =>
            {
                try
                {
                    var sample = this.Bind<Sample>();
                    sample.Timestamp = DateTime.UtcNow;

                    if (!String.IsNullOrWhiteSpace(sample.SensorId))
                        svc.Create(sample);
                }
                catch (Exception)
                {
                    return HttpStatusCode.BadRequest;
                }

                return HttpStatusCode.OK;
            };
        }

    }
}
