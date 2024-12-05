using FluentValidation;
using Infrastructure.Entity.Context;
using Infrastructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleApplicationLayer.DTO;

namespace VehicleApplicationLayer.Validators
{
    public class InsertVehicleDTOValidator : AbstractValidator<VehicleDTO>
    {
        private readonly VehicleDbContext _dbContext;
        public InsertVehicleDTOValidator(VehicleDbContext forkliftDbContext)
        {
            _dbContext = forkliftDbContext;

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(50).WithMessage("Company name cannot exceed 50 characters.");

            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage("Model name is required.")
                .MaximumLength(100).WithMessage("Model name cannot exceed 100 characters.");

            RuleFor(x => x.SerialNumber)
                .NotEmpty().WithMessage("Serial number is required.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is requires.");

            RuleFor(x => x.StartDate)
                .Must(CheckStartDate).WithMessage("The start date must not be less than today");

            RuleFor(x => x.VehicleType)
                .NotEmpty().WithMessage("Type is required");

            RuleFor(x => x.VehicleType)
                .Must(CheckIfTypeExist).WithMessage("Type is not exist");

        }

        bool CheckStartDate(DateTime startDate)
        {
            return !(startDate.Date < DateTime.Now.Date);
        }

        bool CheckIfTypeExist(int typeId)
        {
            return _dbContext.VehicleTypes.Any(x => x.VehicleType_Id == typeId);
        }
    }
}
