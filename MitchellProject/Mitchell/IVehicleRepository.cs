using Mitchell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitchell
{
    interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicle();
        Vehicle GetById(String id);
        void Update(Vehicle vehicle);
        void DeleteById(String id);

    }
}
