using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Domain
{
    public interface ISampleService
    {
        List<Sample> GetAll();
        List<Sample> GetBySensor(string sensorId);
        void Create(Sample model);
    }
}
