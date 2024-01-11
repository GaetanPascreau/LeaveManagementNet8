using AutoMapper;
using LeaveManagementNet8.Data;
using LeaveManagementNet8.Common.Models;

namespace LeaveManagementNet8.Application.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<Employee, EmployeeListVM>().ReverseMap();
            CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>().ReverseMap();
            CreateMap<LeaveRequestCreateVM, LeaveRequest>().ReverseMap();
            CreateMap<LeaveRequestVM, LeaveRequest>().ReverseMap();
        }
    }
}
