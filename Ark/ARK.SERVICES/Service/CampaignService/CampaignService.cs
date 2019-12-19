using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARK.CORE.Data;
using ARK.CORE.Infrastructure;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Campaign;
using Microsoft.EntityFrameworkCore;

namespace ARK.SERVICES.Service.CampaignService
{
    public class CampaignService : ICampaignService
    {
        private IRepository<CampaignParameterList> _campaignParameterListRepository;
        private IRepository<Campaign> _campaignRepository;
        private IRepository<CampaignSpeed> _speedRepository;
        public CampaignService(
            IRepository<CampaignParameterList> campaignParameterListRepository,
            IRepository<Campaign> campaignRepository,
            IRepository<CampaignSpeed> speedRepository
            )
        {
            _campaignParameterListRepository = campaignParameterListRepository;
            _campaignRepository = campaignRepository;
            _speedRepository = speedRepository;
        }

        public async Task<ServiceResponse<List<CampaignParameterListModel>>> GetCampaignParameterList(
            int? code = null, string name = null, string codeName = null, int? mainId = null, int? parentId = null, string value = null,
            bool? isActive = null
            )
        {
            try
            {
                var campParList = _campaignParameterListRepository.TableNoTracking;
                if (code != null && code > 0) campParList = campParList.Where(x => x.Code.Equals(code));
                if (name != null && !name.Equals("")) campParList = campParList.Where(x => x.Name.Equals(name));
                if (codeName != null && !codeName.Equals("")) campParList = campParList.Where(x => x.CodeName.Equals(codeName));
                if (mainId != null && mainId > 0) campParList = campParList.Where(x => x.MainId.Equals(mainId));
                if (parentId != null && parentId > 0) campParList = campParList.Where(x => x.ParentId.Equals(parentId));
                if (value != null && !value.Equals("")) campParList = campParList.Where(x => x.Value.Equals(value));
                if (isActive != null) campParList = campParList.Where(x => x.IsActive.Equals((bool)isActive));
                var lists = await campParList.ToListAsync();
                return new ServiceResponse<List<CampaignParameterListModel>>(lists.Select(ConvertExtension.Convert<CampaignParameterListModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<CampaignParameterListModel>>(ex);
            }
        }

        public async Task<ServiceResponse<List<CampaignModel>>> GetCampaigns()
        {
            try
            {
                var campaigns = _campaignRepository.TableNoTracking;
                //if (code != null && code > 0) campParList = campParList.Where(x => x.Code.Equals(code));
                //if (name != null && !name.Equals("")) campParList = campParList.Where(x => x.Name.Equals(name));
                //if (codeName != null && !codeName.Equals("")) campParList = campParList.Where(x => x.CodeName.Equals(codeName));
                //if (mainId != null && mainId > 0) campParList = campParList.Where(x => x.MainId.Equals(mainId));
                //if (parentId != null && parentId > 0) campParList = campParList.Where(x => x.ParentId.Equals(parentId));
                //if (value != null && !value.Equals("")) campParList = campParList.Where(x => x.Value.Equals(value));
                //if (isActive != null) campParList = campParList.Where(x => x.IsActive.Equals((bool)isActive));
                var lists = await campaigns.ToListAsync();
                return new ServiceResponse<List<CampaignModel>>(lists.Select(ConvertExtension.Convert<CampaignModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<CampaignModel>>(ex);
            }
        }

        public async Task<ServiceResponse<List<CampaignSpeedModel>>> GetCampaignSpeeds()
        {
            try
            {
                var speeds = _speedRepository.TableNoTracking;
                //if (code != null && code > 0) campParList = campParList.Where(x => x.Code.Equals(code));
                //if (name != null && !name.Equals("")) campParList = campParList.Where(x => x.Name.Equals(name));
                //if (codeName != null && !codeName.Equals("")) campParList = campParList.Where(x => x.CodeName.Equals(codeName));
                //if (mainId != null && mainId > 0) campParList = campParList.Where(x => x.MainId.Equals(mainId));
                //if (parentId != null && parentId > 0) campParList = campParList.Where(x => x.ParentId.Equals(parentId));
                //if (value != null && !value.Equals("")) campParList = campParList.Where(x => x.Value.Equals(value));
                //if (isActive != null) campParList = campParList.Where(x => x.IsActive.Equals((bool)isActive));
                var lists = await speeds.ToListAsync();
                return new ServiceResponse<List<CampaignSpeedModel>>(lists.Select(ConvertExtension.Convert<CampaignSpeedModel>).ToList(), true, 100, "");
            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<CampaignSpeedModel>>(ex);
            }
        }
    }
}