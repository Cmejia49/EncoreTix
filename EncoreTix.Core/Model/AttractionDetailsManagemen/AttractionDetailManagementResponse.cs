using EncoreTix.Core.Model.AttractionServices;
using EncoreTix.Core.Model.EventServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Model.AttractionDetailsManagemen
{
    public class AttractionDetailManagementResponse
    {
        public AttractionDetailResponse Attraction { get; set; }
        public List<Event> EventList { get; set; }
    }
}
