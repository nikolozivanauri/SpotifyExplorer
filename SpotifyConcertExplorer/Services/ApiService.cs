using SpotifyExplorer.Configs;

namespace SpotifyExplorer.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfig _config;

        public ApiService(HttpClient httpClient, AppConfig config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> FetchEventsFromApiAsync()
        {
            string endpoint = _config.ApiEndpoint;
            string apiKey = _config.ApiKey;

            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "spotify23.p.rapidapi.com");

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
