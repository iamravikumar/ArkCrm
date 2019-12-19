using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain;
using ARK.MODEL.V1.Domain.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public interface ICustomerBusiness : IBusiness
    {
        ServiceResponse<Customer> GetFilteredCustomers(FilterContainer filterContainer);
        ServiceResponse<CustomerModel> CreateCustomer(CustomerModel newCustomer);
        ServiceResponse<CustomerModel> UpdateCustomer(CustomerModel newCustomer);
        Task<ServiceResponse<PreCustomerModel>> GetPreCustomer();

        Task<ServiceResponse<List<CustomerViewModel>>> GetCustomers();
        Task<ServiceResponse<List<CustomerViewModel>>> GetCustomerAccounts();
    }
}
