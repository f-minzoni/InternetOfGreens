using InternetOfGreens.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Data
{
    public class PlantService  : MongoRepository<Plant>, IPlantService 
    {
        public PlantService() : base("plants") { }

        public List<Plant> GetAll()
        {
            return base.All().ToList();
        }

    }
}
