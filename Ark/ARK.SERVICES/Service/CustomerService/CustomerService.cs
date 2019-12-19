using ARK.CORE.Data;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerView> _customerViewRepository;
        private readonly IRepository<AccountView> _accountViewRepository;

        public CustomerService(
            IRepository<Customer> customerRepository
            , IRepository<CustomerView> customerViewRepository
            , IRepository<AccountView> accountViewRepository
            )
        {
            _customerRepository = customerRepository;
            _customerViewRepository = customerViewRepository;
            _accountViewRepository = accountViewRepository;
        }

        public PagedList<Customer> GetCustomers(FilterContainer filterContainer)
        {
            try
            {
                var asd = _customerRepository.TableNoTracking;

                return new PagedList<Customer>(asd, filterContainer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customer CreateCustomer(Customer newCustomer)
        {
            try
            {
                _customerRepository.Insert(newCustomer);

                return new Customer();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customer UpdateCustomer(Customer newCustomer)
        {
            try
            {
                _customerRepository.Update(newCustomer);

                return new Customer();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ServiceResponse<bool> DeleteCustomer(long customerId, bool isHardDelete = false)
        {
            try
            {
                //if (isHardDelete) _customerRepository.DeleteAb(newCustomer);
                //else _customerRepository.Delete(newCustomer);
                
                

                return new ServiceResponse<bool>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<CustomerView>> GetCustomersAsync()
        {
            try
            {
                var asd = await Task.Run(() => GetCustomers());
                return asd;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CustomerView> GetCustomers()
        {
            try
            {
                var asd = _customerViewRepository.TableNoTracking;

                return asd.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<CustomerView>> GetCustomerAccountsAsync()
        {
            try
            {
                var asd = await Task.Run(() => GetCustomers());
                return asd;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CustomerView> GetCustomerAccounts()
        {
            try
            {
                var asd = _customerViewRepository.TableNoTracking;

                return asd.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
