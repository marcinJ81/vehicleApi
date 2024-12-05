using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Model
{
    public class Vehicle
    {
        [Key]
        public int Vehicle_Id { get; set; }
        public string Vehicle_Model { get; set; }
        public string Vehicle_Company { get; set; }
        public string Vehicle_SerialNumber { get; set; }
        public DateTime Vehicle_StartDate { get; set; }
        public decimal Vehicle_StartingMileage { get; set; }
        public int VehicleType_id { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool Vehicle_Status { get; set; }
        public ICollection<VehicleMth> MthRegisters { get; set; }
    }
    
}
