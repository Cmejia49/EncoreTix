using EncoreTix.Core.Model.AttractionServices;
using EncoreTix.Core.Model.EventServices;
using EncoreTix.Core.Services.AttractionService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services.EvenServices
{
    public class EventService : ServiceBase, IEventService
    {
        public EventService(HttpClient httpClient, ILogger<ServiceBase> logger) : base(httpClient, logger)
        {
        }

        public async Task<EventListResponse> GetEventListAsync(string attractionId)
        {
            try
            {
                var requestUrl = $"events.json?attractionId={attractionId}";
                return await SendRequestAsync<EventListResponse>(requestUrl);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
