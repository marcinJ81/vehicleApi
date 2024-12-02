using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Model
{
    public class VehicleType
    {
        [Key]
        public int VehicleType_Id { get; set; }
        public string VehicleType_Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
