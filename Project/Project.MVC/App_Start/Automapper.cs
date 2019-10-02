using AutoMapper;
using Project.Service.Models;
using Project.Service.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Project.MVC.App_Start
{
    public class Automapper
    {
        public static void MappsAuto()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleMake, MakeView>().ReverseMap();
                config.CreateMap<VehicleModel, ModelView>().ReverseMap();
            });
        }
    }
}