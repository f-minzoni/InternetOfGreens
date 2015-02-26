using InternetOfGreens.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Data
{
    public class SampleService  : MongoRepository<Sample>, ISampleService 
    {
        public SampleService() : base("samples") { }

        public List<Sample> GetAll()
        {
            return base.All().ToList();
        }

        public List<Sample> GetBySensor(string sensorId)
        {
            Expression<Func<Sample, bool>> find = s => s.SensorId == sensorId;
            return base.Filter(find).ToList();
        }

    }
}
