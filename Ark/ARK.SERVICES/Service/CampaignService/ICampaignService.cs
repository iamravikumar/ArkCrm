using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.Campaign;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.CampaignService
{
    public interface ICampaignService : IService
    {
        Task<ServiceResponse<List<CampaignParameterListModel>>> GetCampaignParameterList(int? code = null, string name = null, string codeName = null, int? mainId = null, int? parentId = null, string value = null, bool? isActive = null);
        Task<ServiceResponse<List<CampaignModel>>> GetCampaigns();
        Task<ServiceResponse<List<CampaignSpeedModel>>> GetCampaignSpeeds();
    }
}
