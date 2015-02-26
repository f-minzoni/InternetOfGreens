using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Domain
{
    public interface ISensorService
    {
        List<Sensor> GetAll();
        List<Sensor> GetByPlant(string plantId);
    }
}
