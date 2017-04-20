using AutoMapper;
using EMS.Domain.Hrm.Dto;
using EMS.Domain.Hrm.Entities;

namespace EMS.Infra.CrossCutting.Automapper
{
    public class HRMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "HRMappingProfileMappings"; }
        }

        public HRMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}