using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Domain
{
    public class Plant : MongoEntity
    {        
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
