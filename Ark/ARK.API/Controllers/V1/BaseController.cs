using ARK.CORE.Request;
using ARK.MODEL.V1.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ARK.API.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        WeblogConfiguration Config { get; }
        public BaseController()
        {

        }

        public BaseController(IOptions<WeblogConfiguration> options)
        {
            Config = options.Value;
        }

        protected FilterContainer MapQueryFilter(RequestFilter queryFilter)
        {
            var filterContainer = new FilterContainer
            {
                FilterQueries = queryFilter.Filtering?.Select(MapFilter).ToList() ?? new List<FilterQuery>(),
                FilterOrders = queryFilter.Ordering?.Select(x => new FilterOrder(x.FieldName, x.OrderDirection)).ToList() ?? new List<FilterOrder>(),
                FilterPage = new FilterPage { PageNumber = queryFilter.Paging.PageNumber, PageSize = queryFilter.Paging.PageSize, IsPagedList = queryFilter.Paging.IsPagedList }
            };

            return filterContainer;
        }

        private FilterQuery MapFilter(FilterQuery queryFilter)
        {
            queryFilter.FilterValue = queryFilter.FilterValue.StartsWith('+') ? queryFilter.FilterValue : WebUtility.UrlDecode(queryFilter.FilterValue);
            var mappedFilterModel = new FilterQuery(queryFilter.FilterName, queryFilter.Clause, queryFilter.Condition, queryFilter.FilterValue);

            if (queryFilter.SubFilters != null && queryFilter.SubFilters.Any())
                mappedFilterModel.SubFilters = queryFilter.SubFilters.Select(MapFilter).ToList();

            return mappedFilterModel;
        }
    }
}
