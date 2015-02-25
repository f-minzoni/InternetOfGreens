using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetOfGreens.Domain;

namespace InternetOfGreens
{
    public class PlantModule : NancyModule
    {
        public PlantModule(IPlantService svc)
            : base("/plants")
        {
            Get["/"] = x =>
            {
                return Response.AsJson<object>(svc.GetAll());
            };
        }

    }
}
