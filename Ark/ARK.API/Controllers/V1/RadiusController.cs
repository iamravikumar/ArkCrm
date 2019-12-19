using System.Collections.Generic;
using ARK.BUSINESS.Domain;
using ARK.RADIUS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class RadiusController : BaseController
    {
        private readonly IRadiusBusiness _radiusBusiness;
        public RadiusController(IRadiusBusiness radiusBusiness)
        {
            _radiusBusiness = radiusBusiness;
        }
        // GET: api/Radius
        [HttpGet]
        public List<Nas> Get()
        {
            try
            {
                var asd = _radiusBusiness.GetNas().ListData;
                return asd;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
