using AutomapperPlayground.DTO;

namespace AutomapperPlayground.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerListResponse>> GetCustomerList();

        Task<CustomerDetailResponse> GetCustomerDetails(int id);

        Task<CustomerCreateResponse> CreateCustomer(CustomerCreateRequest request);

        Task<CustomerUpdateResponse> UpdateCustomer(int id, CustomerUpdateRequest request);

        Task DeleteCustomer(int id);
    }
}
