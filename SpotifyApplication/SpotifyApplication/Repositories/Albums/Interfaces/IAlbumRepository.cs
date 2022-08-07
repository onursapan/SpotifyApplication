using SpotifyApplication.Domain.Albums;

namespace SpotifyApplication.Repositories.Albums.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbumList();
        Task<Album> GetAlbumById(int albumId);
        Task<bool> CreateAlbum(Album album);
    }
    
}
