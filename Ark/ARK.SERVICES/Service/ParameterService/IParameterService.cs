using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.Parameter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.ParameterService
{
    public interface IParameterService : IService
    {
        Task<ServiceResponse<List<ParameterModel>>> GetParameterAsync(int? code = null, string name = null);
        Task<ServiceResponse<List<ParameterListModel>>> GetParameterListAsync(int? code = null, string codeName = null);
        ServiceResponse<ParameterModel> GetParameter(int? code = null, string name = null);
        ServiceResponse<List<ParameterListModel>> GetParameterList(int? code = null, string codeName = null);
    }
}
