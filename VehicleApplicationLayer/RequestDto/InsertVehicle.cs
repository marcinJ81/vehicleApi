using Infrastructure.Command;
using Infrastructure.Entity.Model;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApplicationLayer.DTO;

namespace VehicleApplicationLayer.RequestDto
{
    public class InsertVehicle : IRequest<Unit>
    {
        public VehicleDTO dtoModel { get; set; }
    }
 
    public class InsertVehicleRequestHandle : IRequestHandler<InsertVehicle, Unit>
    {
        private readonly IVehicleCommand _vehicleCommad;
        public InsertVehicleRequestHandle(
            IVehicleCommand vehicleCommand)
        {
            _vehicleCommad = vehicleCommand;
        }

        public Task<Unit> Handle(InsertVehicle request, CancellationToken cancellationToken)
        {
            //dto model
            var model = new CreateObject(request.dtoModel).VehicleModel;
            _vehicleCommad.InsertVehcle(model);
            return Task.FromResult(Unit.Value);
        }
    }

    internal class CreateObject
    {
        internal Vehicle VehicleModel { get; private set; }
        public CreateObject(VehicleDTO request)
        {
            this.VehicleModel = new Vehicle()
            { 
                Vehicle_Company = request.CompanyName,
                VehicleType_id = request.VehicleType,
                Vehicle_Model = request.ModelName,
                Vehicle_SerialNumber = request.SerialNumber,
                Vehicle_StartDate = request.StartDate,
                Vehicle_StartingMileage = request.Mileage
            };
        }
    }
}
