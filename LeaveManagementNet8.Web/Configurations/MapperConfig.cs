using AutoMapper;
using LeaveManagementNet8.Web.Data;
using LeaveManagementNet8.Web.Models;

namespace LeaveManagementNet8.Web.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
