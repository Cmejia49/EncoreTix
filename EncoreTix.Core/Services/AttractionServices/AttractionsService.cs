using EncoreTix.Core.Model.AttractionServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services.AttractionService
{
    public class AttractionsService : ServiceBase, IAttractionsService
    {
        public AttractionsService(HttpClient httpClient, ILogger<ServiceBase> logger) : base(httpClient, logger)
        {
        }

        public async Task<AttractionDetailResponse> GetAttractionDetailAsync(string attractionId)
        {
            try
            {
                var requestUrl = $"attractions/{attractionId}.json";
                return await SendRequestAsync<AttractionDetailResponse>(requestUrl);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<AttractionListResponse> GetAttractionListAsync(string keyword)
        {

            try
            {

                var requestUrl = $"attractions.json?keyword={(string.IsNullOrEmpty(keyword) ? "PHISH" : keyword)}";
                return await SendRequestAsync<AttractionListResponse>(requestUrl);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
