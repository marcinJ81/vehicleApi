using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Model
{
    public class VehicleMth
    {
        [Key]
        public int Mth_Id { get; set; }
        public decimal Mth_Register { get; set; }
        public DateTime Mth_RegisterDate { get; set; }
        public DateTime Mth_RegisterInsert { get; set; }
        public int Vehicle_Id { get; set; }
        public Vehicle Vehicle { get; set; }
    }


}
