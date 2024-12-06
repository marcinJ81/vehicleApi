using Infrastructure.Entity.Context;
using Infrastructure.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public interface IVehicleQuery
    {
        Task<List<Vehicle>> GetVehicles();
    }

    public class VehiclesQuery : IVehicleQuery
    {
        public readonly VehicleDbContext _vehicleDbcontext;
        public VehiclesQuery(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbcontext = vehicleDbContext;
        }
        public async Task<List<Vehicle>> GetVehicles()
        {
            return _vehicleDbcontext.Vehicles
                                    .Include(x => x.VehicleType)
                                    .ToList();
        }
    }
}
