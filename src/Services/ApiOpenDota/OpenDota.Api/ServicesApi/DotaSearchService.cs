using Newtonsoft.Json;
using OpenDota.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpenDota.Api.ServicesApi
{
    public class DotaSearchService
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public DotaSearchService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.opendota.com/api/")
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<PlayerRank>> GetPlayersRank() => await GetAllPlayersRank("playersByRank");
        public async Task<List<Hero>> GetHeroes() => await GetAllHeroes("heroes");
        private async Task<List<Hero>> GetAllHeroes(string arg)
        {
            var listHeroes = new List<Hero>();
            var response = await _client.GetAsync(arg);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                listHeroes = JsonConvert.DeserializeObject<List<Hero>>(json);
            }

            return listHeroes;
        }
        private async Task<List<PlayerRank>> GetAllPlayersRank(string arg)
        {
            var listPlayers = new List<PlayerRank>();

            var response = await _client.GetAsync(arg);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                listPlayers = JsonConvert.DeserializeObject<List<PlayerRank>>(json);
            }

            return listPlayers.Take(10).ToList();
        }
    }
}
