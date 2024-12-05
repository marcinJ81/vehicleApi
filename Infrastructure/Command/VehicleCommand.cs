using Infrastructure.Entity.Context;
using Infrastructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public interface IVehicleCommand
    {
        Task InsertVehcle(Vehicle vehicle);
    }
    public class VehicleCommand : IVehicleCommand
    {
        public readonly VehicleDbContext _vehicleDbcontext; 
        public VehicleCommand(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbcontext = vehicleDbContext;
        }
        public async Task InsertVehcle(Vehicle vehicle)
        {
            _vehicleDbcontext.Vehicles.Add(vehicle);
            _vehicleDbcontext.SaveChanges();
        }
    }
}
