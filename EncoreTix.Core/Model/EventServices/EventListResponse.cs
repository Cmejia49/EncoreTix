using EncoreTix.Core.Model.AttractionServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace EncoreTix.Core.Model.EventServices
{
    public class EventListResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedEvent Embedded { get; set; }
    }
    public class EmbeddedEvent
    {
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; }
    }
    public class Event
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("dates")]
        public Dates Dates { get; set; }

        [JsonPropertyName("_embedded")]
        public EmbeddedVuenues Embedded { get; set; }
    }
    public class Dates
    {
        [JsonPropertyName("start")]
        public Start Start { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }

    public class Start
    {
        [JsonPropertyName("localDate")]
        public string LocalDate { get; set; }

        [JsonPropertyName("localTime")]
        public string LocalTime { get; set; }

        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("dateTBD")]
        public bool DateTBD { get; set; }

        [JsonPropertyName("dateTBA")]
        public bool DateTBA { get; set; }

        [JsonPropertyName("timeTBA")]
        public bool TimeTBA { get; set; }

        [JsonPropertyName("noSpecificTime")]
        public bool NoSpecificTime { get; set; }
    }

    public class EmbeddedVuenues
    {
        [JsonPropertyName("venues")]
        public List<Venue> Venues { get; set; }
    }

    public class Venue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
