using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetOfGreens.Domain;

namespace InternetOfGreens
{
    public class SensorModule : NancyModule
    {
        public SensorModule(ISensorService svc)
            : base("/sensors")
        {
            Get["/"] = x =>
            {
                return Response.AsJson<object>(svc.GetAll());
            };

            Get["/plant/{plantId}"] = parameters =>
            {
                List<Sensor> sensors = svc.GetByPlant(parameters.plantId);
                return Response.AsJson<object>(sensors);
            };
        }

    }
}
