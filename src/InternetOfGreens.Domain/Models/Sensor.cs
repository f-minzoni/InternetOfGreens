using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Domain
{
    public class Sensor : MongoEntity
    {        
        public string Description { get; set; }
        public string Type { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double StepValue { get; set; }
        public List<Plant> Plants { get; set; }
    }
}
