using PagedList;
using Project.Service.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.CRUD
{
    public interface IVehicleService
    {
        void CreateVehicleMake(MakeView makeView);
        MakeView FindIdMake(int? id);
        void EditVehicleMake(MakeView makeView);
        void DeleteVehicleMake(int id);
        List<MakeView> GetAllVehicleMakes();
        void CreateVehicleModel(ModelView modelView);
        ModelView FindIdModel(int? id);
        void EditVehicleModel(ModelView modelView);
        void DeleteVehicleModel(int id);
        List<ModelView> GetAllVehicleModels();
        IPagedList<MakeView> SortFilterPagingMake(string sortOrder, string searchString, string searchBy, int? page);
        IPagedList<ModelView> SortFilterPagingModel(string sortOrder, string searchString, string searchBy, int? page);
    }
}
