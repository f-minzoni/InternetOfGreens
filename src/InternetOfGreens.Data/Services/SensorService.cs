using InternetOfGreens.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Data
{
    public class SensorService  : MongoRepository<Sensor>, ISensorService 
    {
        public SensorService() : base("sensors") { }

        public List<Sensor> GetAll()
        {
            return base.All().ToList();
        }

        public List<Sensor> GetByPlant(string plantId)
        {
            var id = ObjectId.Parse(plantId);
            Expression<Func<Sensor, bool>> find = s => s.Plants.Any(p => p.Id == id);
            return base.Filter(find).ToList();
        }
    }
}
