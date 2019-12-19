using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.CORE.Data;
using ARK.CORE.Infrastructure;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.TaxAdministration;
using Microsoft.EntityFrameworkCore;

namespace ARK.SERVICES.Service.TaxAdministration
{
    public class TaxAdministrationService : ITaxAdministrationService
    {
        private IRepository<TaxAdministrationCity> _taxCityRepository;
        private IRepository<TaxAdministrationDistrict> _taxDistrictRepository;
        public TaxAdministrationService(
            IRepository<TaxAdministrationCity> taxCityRepository,
            IRepository<TaxAdministrationDistrict> taxDistrictRepository
            )
        {
            _taxCityRepository = taxCityRepository;
            _taxDistrictRepository = taxDistrictRepository;
        }
        public async Task<ServiceResponse<List<TaxAdministrationDistrictModel>>> GetTaxAdministrationDistricts()
        {
            try
            {
                var districts = await _taxDistrictRepository.TableNoTracking.ToListAsync();
                var districts2 = districts.Select(ConvertExtension.Convert<TaxAdministrationDistrictModel>).ToList();
                return new ServiceResponse<List<TaxAdministrationDistrictModel>>(districts2, true, 1, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<TaxAdministrationDistrictModel>>(ex);
            }
        }

        public async Task<ServiceResponse<List<TaxAdministrationCityModel>>> GetTaxAdministrationCities()
        {
            try
            {
                var cities = await _taxCityRepository.TableNoTracking.ToListAsync();
                var cities2 = cities.Select(ConvertExtension.Convert<TaxAdministrationCityModel>).ToList();
                return new ServiceResponse<List<TaxAdministrationCityModel>>(cities2, true, 1, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<TaxAdministrationCityModel>>(ex);
            }
        }
    }
}
