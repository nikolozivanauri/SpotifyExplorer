namespace SpotifyExplorer.Contracts
{
    public class Event
    {
        public List<string> Artists { get; set; }
        public string Venue { get; set; }
        public string Location { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public List<Concert> Concerts { get; set; }
        public string Title { get; set; }
     }
}
