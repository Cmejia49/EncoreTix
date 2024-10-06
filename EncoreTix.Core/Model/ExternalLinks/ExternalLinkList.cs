using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncoreTix.Core.Model.ExternalLinks
{
    public class ExternalLinkList
    {
        [JsonPropertyName("youtube")]
        public List<ExternalLinkItem> Youtube { get; set; }

    }

    public class ExternalLinkItem
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class MusicBrainzItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

}
