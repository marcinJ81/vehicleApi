using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApplicationLayer.DTO
{
    public record VehicleDTO
    {
        public string ModelName { get; init; }
        public string CompanyName { get; init; }
        public string SerialNumber { get; init; }
        public DateTime StartDate { get; init; }
        public decimal Mileage { get; init; }
        public int VehicleType { get; init; }
    }
}
