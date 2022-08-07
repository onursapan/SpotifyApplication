using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;

namespace SpotifyApplication.Services.Artists.Interfaces
{
    public interface IArtistService
    {
        List<ArtistResponse> GetArtistList(string artistId);
        //Task<AlbumResponse?> GetArtistById(int albumId);
        Task<bool> CreateArtist(CreateArtistRequest request);    }
}
