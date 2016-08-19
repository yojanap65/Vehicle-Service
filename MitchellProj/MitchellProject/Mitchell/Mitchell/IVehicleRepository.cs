using Mitchell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitchell
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();
        Vehicle GetById(int id);
        bool AddVehicle(Vehicle vehicle);
        bool DeleteById(int id);
        

    }
}
