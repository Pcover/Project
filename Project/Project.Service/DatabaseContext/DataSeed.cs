using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DatabaseContext
{
    public class DataSeed : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            VehicleMake vehicleMake = new VehicleMake()
            {
             
                Name = "Volkswagen",
                Abrv = "VW",
                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                        
                        Name = "Passat",
                        Abrv = "VW",
                        inStock = true
                    },
                    new VehicleModel()
                    {
                        
                        Name = "Golf V",
                        Abrv = "VW",
                        inStock = true
                    }
                }
            };


            VehicleMake vehicleMake1 = new VehicleMake()
            {
             
                Name = "General Motors Company",
                Abrv = "GMC",

                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                      
                       Name = "Sierra HD",
                       Abrv = "GMC",
                       inStock = true
                    },
                    new VehicleModel()
                    {
                     
                       Name = "Sierra",
                       Abrv = "GMC",
                       inStock = true

                    }
                }
            };



            VehicleMake vehicleMake2 = new VehicleMake()
            {
               
                Name = "Bayerische Motoren Werke",
                Abrv = "BMW",
                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                       
                        Name = "i3",
                        Abrv = "BMW",
                        inStock = true
                    },
                    new VehicleModel()
                    {
                    
                        Name = "M5",
                        Abrv = "BMW",
                        inStock = true
                    }
                }
            };


            VehicleMake vehicleMake3 = new VehicleMake()
            {
                
                Name = "Chevrolet",
                Abrv = "CV",

                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                       
                       Name = "Cruze",
                       Abrv = "CV",
                       inStock = true
                    },
                    new VehicleModel()
                    {
                       
                       Name = "Malibu",
                       Abrv = "CV",
                       inStock = true

                    }
                }
            };



            VehicleMake vehicleMake4 = new VehicleMake()
            {
             
                Name = "Peugeot",
                Abrv = "PG",
                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                       
                        Name = "4007",
                        Abrv = "PG",
                        inStock = true
                    },
                    new VehicleModel()
                    {
                      
                        Name = "301",
                        Abrv = "PG",
                        inStock = true
                    }
                }
            };


            VehicleMake vehicleMake5 = new VehicleMake()
            {
               
                Name = "Mercedes-Benz",
                Abrv = "MB",

                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                      
                       Name = "Maybach",
                       Abrv = "MB",
                       inStock = true
                    },
                    new VehicleModel()
                    {
                     
                       Name = "AMG GT",
                       Abrv = "MB",
                       inStock = true

                    }
                }
            };


            context.VehicleMakes.Add(vehicleMake);
            context.VehicleMakes.Add(vehicleMake1);
            context.VehicleMakes.Add(vehicleMake2);
            context.VehicleMakes.Add(vehicleMake3);
            context.VehicleMakes.Add(vehicleMake4);
            context.VehicleMakes.Add(vehicleMake5);
            base.Seed(context);
        }
    }
}

