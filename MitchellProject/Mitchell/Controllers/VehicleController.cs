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
        private List<Vehicle> Vehicles = new List<Vehicle>();
      
        public vehiclesController()
        {
            Vehicle v1 = new Vehicle {Id = 1, Year = 2010, Make = "Toyota", Model = "corolla" };
            Vehicle v2 = new Vehicle {Id = 2, Year = 2012, Make = "HUUU", Model = "108DJ" };
            Vehicle v3 = new Vehicle {Id = 3 , Year = 2016, Make = "bmw", Model = "x5" };
            Vehicle v4 = new Vehicle {Id = 4, Year = 2008, Make = "Hyundai", Model = "2005" };
          
                Vehicles.Add(v1);
                Vehicles.Add(v2);
                Vehicles.Add(v3);
                Vehicles.Add(v4);                              

        }

        /*[WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Vehicle AddNewVehicle(Vehicle newVehicle)
        {
         if (!IsEmpty(newVehicle.Make) && !IsEmpty(newVehicle.Model) && validateYear(newVehicle.Year))
            { 
            if (newVehicle == null)
                throw new ArgumentNullException("newVehicle"); newVehicle.Id = counter++;
            Vehicles.Add(newVehicle);
            }
            return newVehicle;
        }*/

        // GET api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<Vehicle> Get()
        {
            return Vehicles;
        }

        // GET vehicle with required Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Vehicle Get(int id)
        {
            return Vehicles.Find(b => b.Id == id);
        }
        
        //Check if vehicle is present or not
        public Boolean IsEmpty(String vehicle)
        {
            return String.IsNullOrEmpty(vehicle);
        }


        // Validation of vehicle for "YEAR"
        public Boolean validateYear(int year)
        {
           return (year >= 1950 && year <= 2050) ? true : false;
        }

        // POST api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Post([FromBody]Vehicle updatedVehicle)
        {
            if (updatedVehicle == null)
                throw new ArgumentNullException("updatedVehicle");
            int index = Vehicles.FindIndex(b => b.Id == updatedVehicle.Id);
            if (index == -1)
                return false;
            Vehicles.RemoveAt(index);
            Vehicles.Add(updatedVehicle);
                return true;
        }

        // PUT api/<controller>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Put(int id, [FromBody]string value)
        {
            //NA
        }

        // DELETE vehicle with required Id
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool Delete(int Id)
        {
            int index = Vehicles.FindIndex(b => b.Id == Id);
            if (index == -1)
                return false;
            Vehicles.RemoveAll(b => b.Id == Id);
                return true;
        }

        // Get vehicle by make
        public List<Vehicle> GetVehicleByMake(string make)
        {
            return Vehicles.FindAll(b => b.Make == make);
        }

        // Get vehicle by year
        public List<Vehicle> GetVehicleByYear(string year)
        {
            return Vehicles.FindAll(b => b.Year == Int32.Parse(year));
        }

        // Get vehicle by model
        public List<Vehicle> GetVehicleByModel(string model)
        {
            return Vehicles.FindAll(b => b.Model == model);
        }
    }
}