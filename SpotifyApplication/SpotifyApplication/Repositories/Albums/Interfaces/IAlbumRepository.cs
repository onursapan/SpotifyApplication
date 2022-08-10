using SpotifyApplication.Domain.Albums;

namespace SpotifyApplication.Repositories.Albums.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbumList();
        Task<Album> GetAlbumById(int albumId);
        Task<IEnumerable<Album>> GetAlbumByArtistId(int artistId);
        Task<bool> CreateAlbum(Album album);
    }
    
}
