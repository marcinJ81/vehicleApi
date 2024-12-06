using Infrastructure.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApplicationLayer.VM;

namespace VehicleApplicationLayer.RequestDto
{
    public class GetVehicles: IRequest<List<VehicleVm>>
    {
    }
    public class GetVehiclesHandler : IRequestHandler<GetVehicles, List<VehicleVm>>
    {
        private readonly IVehicleQuery _vehicleQuery;

        public GetVehiclesHandler(IVehicleQuery vehicleQuery)
        {
            _vehicleQuery = vehicleQuery;
        }

        public async Task<List<VehicleVm>> Handle(GetVehicles request, CancellationToken cancellationToken)
        {
            var result = await _vehicleQuery.GetVehicles();
            var VehiclesQuery = result.Select(x => new VehicleVm 
            { 
                SerialNumber = x.Vehicle_SerialNumber,
                Mileage = x.Vehicle_StartingMileage.ToString("F2"),
                ModelName = x.Vehicle_Model,
                CompanyName = x.Vehicle_Company,
                StartDate = x.Vehicle_StartDate.Date.ToString("yyyy-MM-dd"),
                VehicleType = x.VehicleType.VehicleType_Name

            }).ToList();
            return VehiclesQuery;
        }
    }
}
