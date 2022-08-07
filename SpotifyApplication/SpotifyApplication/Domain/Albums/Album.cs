using SpotifyApplication.Domain.Base;

namespace SpotifyApplication.Domain.Albums
{
    public class Album : AuditableBase
    {
        public string Name { get; set; }
        public DateTime RelaseDate { get; set; }
        public int ArtistId { get; set; }
    }
}
