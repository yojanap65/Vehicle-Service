﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mitchell.Models;

namespace Mitchell.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> Vehicles = new List<Vehicle>();
        static int vehicleId = 100;
        public VehicleRepository()
        {
            Vehicle v1 = new Vehicle { Id = 1, Year = 2010, Make = "Toyota", Model = "corolla" };
            Vehicle v2 = new Vehicle { Id = 2, Year = 2012, Make = "HUUU", Model = "108DJ" };
            Vehicle v3 = new Vehicle { Id = 3, Year = 2016, Make = "bmw", Model = "x5" };
            Vehicle v4 = new Vehicle { Id = 4, Year = 2008, Make = "Hyundai", Model = "2005" };

            Vehicles.Add(v1);
            Vehicles.Add(v2);
            Vehicles.Add(v3);
            Vehicles.Add(v4);

        }

        public bool DeleteById(int id)
        {
            int index = Vehicles.FindIndex(b => b.Id == id);
            if (index == -1)
                return false;
            Vehicles.RemoveAll(b => b.Id == id);
            return true;
        }

        public Vehicle GetById(int id)
        {
            return Vehicles.Find(b => b.Id == id);
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return Vehicles;
        }

        public bool AddVehicle(Vehicle newVehicle)
        {
            if (newVehicle == null)
                throw new ArgumentNullException("newVehicle");
            else
            {
                int index = Vehicles.FindIndex(b => b.Id == newVehicle.Id);
                if (index == -1)
                    return false;
                Vehicles.RemoveAt(index);
                vehicleId = vehicleId + 1;
                newVehicle.Id = vehicleId;
                Vehicles.Add(newVehicle);
            }
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
    }
}