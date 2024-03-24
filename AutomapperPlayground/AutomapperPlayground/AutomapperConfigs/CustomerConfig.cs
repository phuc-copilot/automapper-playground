using AutoMapper;
using AutomapperPlayground.DTO;
using AutomapperPlayground.Models;

namespace AutomapperPlayground.AutomapperConfigs
{
    public class CustomerConfig : Profile
    {
        public CustomerConfig()
        {
            CreateMap<Customer, CustomerListResponse>()
                .ForMember(des => des.FullName, src => src.MapFrom(y => y.FirstName + " " + y.LastName)); 

            CreateMap<Customer, CustomerDetailResponse>();
            CreateMap<Customer, CustomerUpdateResponse>();
            CreateMap<Customer, CustomerCreateResponse>();

            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<CustomerUpdateRequest, Customer>();
        }
    }
}
