using EncoreTix.Core.Model.AttractionDetailsManagemen;
using EncoreTix.Core.Model.EventServices;
using EncoreTix.Core.Services.AttractionService;
using EncoreTix.Core.Services.EvenServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Management
{
    public class AttractionDetailManagement : IAttractionDetailManagement
    {
        private readonly IAttractionsService _attractionsService;
        private readonly IEventService _eventService;
        public AttractionDetailManagement(IAttractionsService attractionsService, IEventService eventService)
        {
            _attractionsService = attractionsService;
            _eventService = eventService;
        }

        public async Task<AttractionDetailManagementResponse> GetAttractionDetails(string attractionId)
        {
            var attraction = await _attractionsService.GetAttractionDetailAsync(attractionId);
            var events = await _eventService.GetEventListAsync(attractionId);

            // Null-check for events and embedded events
            var eventList = events?.Embedded?.Events ?? new List<Event>();

            return new AttractionDetailManagementResponse()
            {
                Attraction = attraction,
                EventList = eventList
            };
        }

    }
}
