using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.CORE.Data;
using ARK.CORE.Infrastructure;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Parameter;
using Microsoft.EntityFrameworkCore;

namespace ARK.SERVICES.Service.ParameterService
{
    public class ParameterService : IParameterService
    {
        private IRepository<ParameterList> _parameterListRepository;
        private IRepository<Parameter> _parameterRepository;

        public ParameterService(
            IRepository<ParameterList> parameterListRepository,
            IRepository<DATA.Models.Parameter> parameterRepository
            )
        {
            _parameterListRepository = parameterListRepository;
            _parameterRepository = parameterRepository;
        }

        public ServiceResponse<ParameterModel> GetParameter(int? code = null, string name = null)
        {
            try
            {
                var asd = _parameterRepository.TableNoTracking;
                if (code != null && code > 0) asd = asd.Where(x => x.Code == code);
                if (code != null && code > 0) asd = asd.Where(x => x.Name.Equals(name));
                var asdd = asd.FirstOrDefault();
                return new ServiceResponse<ParameterModel>(ConvertExtension.Convert<ParameterModel>(asdd), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<ParameterModel>(ex);
            }
        }

        public async Task<ServiceResponse<List<ParameterModel>>> GetParameterAsync(int? code = null, string name = null)
        {
            try
            {
                var asd = _parameterRepository.TableNoTracking;
                if (code != null && code > 0) asd = asd.Where(x => x.Code == code);
                if (code != null && code > 0) asd = asd.Where(x => x.Name.Equals(name));
                var asdd = await asd.ToListAsync();
                return new ServiceResponse<List<ParameterModel>>(asdd.Select(ConvertExtension.Convert<ParameterModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<ParameterModel>>(ex);
            }
        }

        public ServiceResponse<List<ParameterListModel>> GetParameterList(int? code = null, string codeName = null)
        {
            try
            {
                var asd = _parameterListRepository.TableNoTracking;
                if (code != null && code > 0) asd = asd.Where(x => x.Code == code);
                if (code != null && code > 0) asd = asd.Where(x => x.CodeName.Equals(codeName));
                var asdd = asd.ToList();
                return new ServiceResponse<List<ParameterListModel>>(asdd.Select(ConvertExtension.Convert<ParameterListModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<ParameterListModel>>(ex);
            }
        }

        public async Task<ServiceResponse<List<ParameterListModel>>> GetParameterListAsync(int? code = null, string codeName = null)
        {
            try
            {
                var asd = _parameterListRepository.TableNoTracking;
                if (code != null && code > 0) asd = asd.Where(x => x.Code == code);
                if (code != null && code > 0) asd = asd.Where(x => x.CodeName.Equals(codeName));
                var asdd = await asd.ToListAsync();
                return new ServiceResponse<List<ParameterListModel>>(asdd.Select(ConvertExtension.Convert<ParameterListModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<ParameterListModel>>(ex);
            }
        }
    }
}
