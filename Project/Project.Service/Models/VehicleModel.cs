using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
    public class VehicleModel
    {
        public int ID { get; set; }
        public int MakeID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public bool inStock { get; set; }
        
 


        [ForeignKey("MakeID")]
        public virtual VehicleMake Make { get; set; }
    }
}


