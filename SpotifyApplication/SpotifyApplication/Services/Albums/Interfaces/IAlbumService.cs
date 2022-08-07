using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;

namespace SpotifyApplication.Services.Albums.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumResponse>?> GetAlbumList();
        Task<AlbumResponse?> GetAlbumById(int albumId);
        Task<bool> CreateAlbum(CreateAlbumRequest request);
    }
}
