using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpenDota.Api.ServicesApi
{
    public class DotaHealthCheckService
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public DotaHealthCheckService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.opendota.com/api/")
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> HealthCheck() => await HealthCheck("status");

        private async Task<bool> HealthCheck(string arg)
        {
            var response = await _client.GetAsync(arg);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
