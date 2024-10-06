using EncoreTix.Core.ApiExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EncoreTix.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ServiceBase> _logger;

        protected ServiceBase(HttpClient httpClient, ILogger<ServiceBase> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        protected async Task<T> SendRequestAsync<T>(string requestUrl)
        {
            // Log the request
            _logger.LogInformation($"Sending request to API: {requestUrl}");

            // Send the GET request
            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            // Check and throw exceptions based on status code
            await HttpStatusToException(response);

            // Read the response content if no exceptions were thrown
            string content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Received response successfully from API.");

            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
                PropertyNameCaseInsensitive = true 
            });
        }

        protected virtual async Task HttpStatusToException(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return; // No exceptions if the response is successful
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new NotFoundException();
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(await response.Content.ReadAsStringAsync());
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException("Forbidden");
                default:
                    var message = $"Unexpected status code: {response.StatusCode}";
                    _logger.LogError(message);
                    throw new Exception(message);
            }
        }
    }
}
