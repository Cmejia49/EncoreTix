using EncoreTix.Core.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private readonly string _apiKey;

        public ApiKeyHandler(IOptions<TicketMasterApiSettings> apiSettings)
        {
            _apiKey = apiSettings.Value.ApiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["apikey"] = _apiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
