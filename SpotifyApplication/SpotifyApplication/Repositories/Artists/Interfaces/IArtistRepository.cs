using SpotifyApplication.Domain.Artists;

namespace SpotifyApplication.Repositories.Artists.Interfaces;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> GetArtistList();
    //Task<Album> GetArtistById(int artistId);
    Task<bool> CreateArtist(Artist artist);
}