﻿using Project.Service.Models;
using Project.Service.ModelsView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.DatabaseContext
{
    public class VehicleContext : DbContext
    {
        public static VehicleContext instance;
        public VehicleContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DataSeed());
        }
           
        public static VehicleContext Instance()
        {
            if (instance == null)
                instance = new VehicleContext();
            return instance;
        }



        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            base.OnModelCreating(modelBuilder);

        }
        



        public System.Data.Entity.DbSet<Project.Service.ModelsView.MakeView> MakeViews { get; set; }

        public System.Data.Entity.DbSet<Project.Service.ModelsView.ModelView> ModelViews { get; set; }
    }
}
