using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SpotifyExplorer.Contracts;
using Newtonsoft.Json;
using SpotifyExplorer.Configs;
using SpotifyExplorer.Services;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddSingleton<HttpClient>()
            .AddTransient<EventService>()
            .AddScoped<SpotifyExplorer.Services.interfaces.ILogger, ConsoleLogger>()
            .AddSingleton(configuration.Get<AppConfig>())
            .AddScoped<ApiService>()
            .BuildServiceProvider();

        var apiService = serviceProvider.GetRequiredService<ApiService>();
        var eventService = serviceProvider.GetRequiredService<EventService>();

        try
        {
            var responseBody = await apiService.FetchEventsFromApiAsync();
            var root = JsonConvert.DeserializeObject<Root>(responseBody);
            var washingtonEvents = eventService.FilterWashingtonEvents(root);
            eventService.PrintEvents(washingtonEvents);
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<SpotifyExplorer.Services.interfaces.ILogger>();
            logger.LogError(ex.Message);
        }
    }
}
