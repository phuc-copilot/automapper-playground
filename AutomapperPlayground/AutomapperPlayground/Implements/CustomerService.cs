using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutomapperPlayground.DTO;
using AutomapperPlayground.Interfaces;
using AutomapperPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomapperPlayground.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerService(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CustomerCreateResponse> CreateCustomer(CustomerCreateRequest request)
        {
            // Dung automapper de tao Customer model tu request
            var customerModel = _mapper.Map<Customer>(request);

            _dbContext.Customers.Add(customerModel);

            await _dbContext.SaveChangesAsync();

            // roi tu Customer minh chuyen thanh response de tra ve
            return _mapper.Map<CustomerCreateResponse>(customerModel);
        }

        public async Task DeleteCustomer(int id)
        {
            await _dbContext.Customers.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<CustomerDetailResponse> GetCustomerDetails(int id)
        {
            // Minh dung ham project to de automapper tu translate thanh cau select cho minh
            // neu ko dung automapper, minh phai viet
            // Select(x => new CustomerDetailResponse{....})

            var customer = await _dbContext.Customers
                .Where(x => x.Id == id)
                .ProjectTo<CustomerDetailResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                throw new Exception("Customer is not found");
            }

            return customer;
        }

        public async Task<List<CustomerListResponse>> GetCustomerList()
        {
            // tuong tu voi customer list, dung Automapper de khoi viet Select dai 
            var customers = await _dbContext.Customers
                .ProjectTo<CustomerListResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return customers;
        }

        public async Task<CustomerUpdateResponse> UpdateCustomer(int id, CustomerUpdateRequest request)
        {
            // gia su o day chi cho update thong tin so dien thoai, email, dia chi, ko cho update FirstName, LastName

            // minh lay Customer co san trong DB ra 
            var existedCustomer = await _dbContext.Customers
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (existedCustomer == null)
            {
                throw new Exception("Customer is not found");
            }

            // Dung automapper de gan nhung thay doi vao Customer co san
            var updateModel = _mapper.Map(request, existedCustomer);

            _dbContext.Customers.Update(updateModel);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CustomerUpdateResponse>(updateModel);
        }
    }
}
