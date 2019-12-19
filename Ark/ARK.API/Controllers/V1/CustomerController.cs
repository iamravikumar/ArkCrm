using System.Collections.Generic;
using System.Threading.Tasks;
using ARK.BUSINESS.Domain;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain;
using ARK.MODEL.V1.Domain.Customer;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class CustomerController : BaseController
    {
        private ICustomerBusiness _customerBusiness;

        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        /// <summary>
        /// Get Pre Informations
        /// </summary>
        /// <remarks>asd remarks</remarks>
        [HttpGet("getPreCustomer", Name = "getPreCustomer")]
        [ProducesResponseType(typeof(ServiceResponse<PreCustomerModel>), 200)]
        public async Task<ServiceResponse<PreCustomerModel>> GetPreCustomer()
        {
            try
            {
                var asd = await _customerBusiness.GetPreCustomer().ConfigureAwait(true);
                return asd;
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<PreCustomerModel>(ex);
            }
        }

        // GET: api/Customer
        [HttpGet("GetCustomers", Name = "GetCustomers")]
        [ProducesResponseType(typeof(ServiceResponse<List<CustomerViewModel>>), 200)]
        public async Task<ServiceResponse<List<CustomerViewModel>>> GetCustomers()
        {
            return await _customerBusiness.GetCustomers().ConfigureAwait(true);
        }

        /// <summary>
        /// asd
        /// </summary>
        /// <remarks>asd remarks</remarks>
        [HttpGet("GetFilteredCustomersM", Name = "GetFilteredCustomersM")]
        [ProducesResponseType(typeof(ServiceResponse<CustomerModel>), 200)]
        public ServiceResponse<Customer> GetFilteredCustomersM([FromQuery] RequestFilter requestFilter)
        {
            return _customerBusiness.GetFilteredCustomers(MapQueryFilter(requestFilter));
        }

        // GET: api/Customer
        [HttpGet("GetCustomerAccounts", Name = "GetCustomerAccounts")]
        [ProducesResponseType(typeof(ServiceResponse<List<CustomerViewModel>>), 200)]
        public async Task<ServiceResponse<List<CustomerViewModel>>> GetCustomerAccounts()
        {
            return await _customerBusiness.GetCustomerAccounts().ConfigureAwait(true);
        }
    }
}
