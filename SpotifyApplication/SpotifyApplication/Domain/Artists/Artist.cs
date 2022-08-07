using SpotifyApplication.Domain.Base;

namespace SpotifyApplication.Domain.Artists;

public class Artist : AuditableBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
}