using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mitchell;
using Mitchell.Controllers;
using Mitchell.Models;
using Mitchell.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestVehicleService
{
    [TestClass]
    class TestService
    {
        
        [TestMethod]
        public void TestGetAllVehicles()
        {

            Vehicle v1 = new Vehicle { Id = 1, Year = 2010, Make = "Toyota", Model = "corolla" };
            var vehicleRepository = new VehicleRepository();

            Assert.AreEqual("true", vehicleRepository.AddVehicle(v1));
        }
    }
}
