using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.CustomerService
{
    public interface ICustomerService : IService
    {
        PagedList<Customer> GetCustomers(FilterContainer filterContainer);
        Customer CreateCustomer(Customer newCustomer);
        Customer UpdateCustomer(Customer newCustomer2);

        //view
        Task<List<CustomerView>> GetCustomersAsync();
        List<CustomerView> GetCustomers();

        Task<List<CustomerView>> GetCustomerAccountsAsync();
        List<CustomerView> GetCustomerAccounts();
    }
}
