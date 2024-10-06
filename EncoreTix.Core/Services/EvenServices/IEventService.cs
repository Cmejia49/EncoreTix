using EncoreTix.Core.Model.EventServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services.EvenServices
{
    public interface IEventService
    {
        Task<EventListResponse> GetEventListAsync(string attractionId);
    }
}
