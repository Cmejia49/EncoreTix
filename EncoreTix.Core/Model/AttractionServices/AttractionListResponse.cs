using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncoreTix.Core.Model.AttractionServices
{
    public class AttractionListResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedAttractionList Embedded { get; set; }
    }

    public class EmbeddedAttractionList
    {
        [JsonPropertyName("attractions")]
        public List<AttractionDetailResponse> Attractions { get; set; }
    }

    public class AttractionDetailResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

    }

    public class Image
    {
        [JsonPropertyName("ratio")]
        public string Ratio { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("fallback")]
        public bool Fallback { get; set; }
    }
}
