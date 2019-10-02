using AutoMapper;
using PagedList;
using Project.Service.DatabaseContext;
using Project.Service.Models;
using Project.Service.ModelsView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.CRUD
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleContext context;
        public static VehicleService instance;

        public VehicleService()
        {
            context = VehicleContext.Instance();
        }

        public static VehicleService Instance()
        {

            if (instance == null)
            {
                instance = new VehicleService();
            }
            return instance;

        }

        public void CreateVehicleMake(MakeView v)
        {
            context.VehicleMakes.Add(Mapper.Map<VehicleMake>(v));
            context.SaveChanges();
        }
      
            public MakeView FindIdMake(int? id)
        {
            VehicleMake Make = context.VehicleMakes.Find(id);
            return Mapper.Map<MakeView>(Make);
        }

        public void EditVehicleMake(MakeView makeView)
        {
            context.Set<VehicleMake>().AddOrUpdate(Mapper.Map<VehicleMake>(makeView));
            context.SaveChanges();
        }
           
         

        public void DeleteVehicleMake(int id)
        {
            VehicleMake Make = context.VehicleMakes.Find(id);
            context.VehicleMakes.Remove(Make);
            context.SaveChanges();
        }

        public List<MakeView> GetAllVehicleMakes()
        {

            return Mapper.Map<List<MakeView>>(context.VehicleMakes.ToList());
        }

        public void CreateVehicleModel(ModelView v)
        {
            context.VehicleModels.Add(Mapper.Map<VehicleModel>(v));
            context.SaveChanges();
        }

        public ModelView FindIdModel(int? id)
        {
            VehicleModel Model = context.VehicleModels.Find(id);
            return Mapper.Map<ModelView>(Model);
        }

        public void EditVehicleModel(ModelView modelView)
        {

            context.Set<VehicleModel>().AddOrUpdate(Mapper.Map<VehicleModel>(modelView));
            context.SaveChanges();
        }

        public void DeleteVehicleModel(int id)
        {
            VehicleModel Model = context.VehicleModels.Find(id);
            context.VehicleModels.Remove(Model);
            context.SaveChanges();
        }

        public List<ModelView> GetAllVehicleModels()
        {

            return Mapper.Map<List<ModelView>>(context.VehicleModels.ToList());
        }

        public IPagedList<MakeView> SortFilterPagingMake(string sortOrder, string searchString, string searchBy, int? page)
        {
            switch (searchBy)
            {
                case "Name":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }
                case "Abrv":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.Where
                                (s => s.Abrv.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }

                default:
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<MakeView>>(context.VehicleMakes.OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);

                    }
            }

        }



        public IPagedList<ModelView> SortFilterPagingModel(string sortOrder, string searchString, string searchBy, int? page)
        {
            switch (searchBy)
            {
                case "Make":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderByDescending(x => x.Make.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Make.Name.Contains(searchString)).OrderBy(x => x.Make.Name)).ToPagedList(page ?? 1, 3);

                    }

                case "Name":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderByDescending(x => x.Make.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Name.Contains(searchString)).OrderBy(x => x.Make.Name)).ToPagedList(page ?? 1, 3);

                    }

                case "Abrv":
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Make.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.Where
                                (s => s.Abrv.Contains(searchString)).OrderBy(x => x.Make.Name)).ToPagedList(page ?? 1, 3);

                    }
                default:
                    switch (sortOrder)
                    {
                        case "make_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderByDescending(x => x.Make.Name)).ToPagedList(page ?? 1, 3);
                        case "Model":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderBy(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "model_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderByDescending(x => x.Name)).ToPagedList(page ?? 1, 3);
                        case "Abrv":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderBy(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        case "abrv_desc":
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderByDescending(x => x.Abrv)).ToPagedList(page ?? 1, 3);
                        default:
                            return Mapper.Map<IEnumerable<ModelView>>(context.VehicleModels.OrderBy(x => x.Make.Name)).ToPagedList(page ?? 1, 3);

                    }
            }
        }
    }
}
