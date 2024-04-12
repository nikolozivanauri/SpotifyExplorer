using SpotifyExplorer.Contracts;

namespace SpotifyExplorer.Services
{
    public class EventService
    {
        public List<Event> FilterWashingtonEvents(Root root)
        {
            string location = "Washington";
            return root.Events.FindAll(e => e.Location == location && e.OpeningDate == e.ClosingDate);
        }

        public void PrintEvents(List<Event> events)
        {
            foreach (var e in events)
            {
                Console.WriteLine($"Title: {e.Title}");
                Console.WriteLine($"Date: {e.OpeningDate}");
                Console.WriteLine($"Venue: {e.Venue}");
                Console.WriteLine($"Number of Artists: {e.Artists.Count}");
                Console.WriteLine($"Number of Concerts: {e.Concerts.Count}");
                Console.WriteLine();
            }
        }
    }
}
