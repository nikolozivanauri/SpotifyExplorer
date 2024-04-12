using SpotifyExplorer.Services.interfaces;

namespace SpotifyExplorer.Services
{
    public class ConsoleLogger: ILogger
    {
        public void LogError(string errorMessage)
        {
            Console.WriteLine($"An error occurred: {errorMessage}");
        }
    }
}
