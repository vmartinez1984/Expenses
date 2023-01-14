using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class DepositPlanMapper: Profile
    {
        public DepositPlanMapper()
        {
            CreateMap<DepositPlanEntity, DepositPlanDtoOut>().ReverseMap();

            CreateMap<DepositPlanEntity, DepositPlanDtoIn>().ReverseMap();

            CreateMap<DepositPlanEntity, DepositPlanFullDtoOut>().ReverseMap();
        }
    }
}