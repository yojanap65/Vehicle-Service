using Mitchell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Web.Http.Cors;
using System.Web.Script.Services;
using System.Web.Services;

namespace Mitchell.Controllers
{
    [EnableCors(origins: "https://estimate-dev.mymitchell.com", headers: "*", methods: "*")]
    public class vehiclesController : ApiController
    {

        private IVehicleRepository _vehicleRepo;
      
      //Dependency injection using constructor
        public vehiclesController(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;                           

        }

        // GET api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleRepo.GetVehicles();
            
        }

        // GET vehicle with required Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Vehicle Get(int id)
        {
            return _vehicleRepo.GetById(id);
          
        }

        // POST api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Post([FromBody]Vehicle updatedVehicle)
        {
            return _vehicleRepo.AddVehicle(updatedVehicle);
          
        }

        // PUT api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Put(Vehicle newVehicle)
        {
            _vehicleRepo.AddVehicle(newVehicle);
        }

        // DELETE vehicle with required Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Delete(int Id)
        {
           return _vehicleRepo.DeleteById(Id);
        }

       
    }
}