using SpotifyApplication.Domain.Albums;
using SpotifyApplication.Repositories.Albums.Interfaces;
using SpotifyApplication.Repositories.Base;

namespace SpotifyApplication.Repositories.Albums.Implementations
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {
        public AlbumRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<Album>> GetAlbumList()
        {
            const string query = @"SELECT * FROM album";
            return await ExecuteQueryAsync<Album>(query).ConfigureAwait(false);
        }

        public async Task<Album> GetAlbumById(int albumId)
        {
            const string query = @"SELECT * FROM album WHERE id = @albumId";
            return await ExecuteQueryFirstOrDefaultAsync<Album>(query, new {albumId}).ConfigureAwait(false);
        }


        public async Task<bool> CreateAlbum(Album album)
        {
            const string query = @"INSERT INTO album
                                   ( 
                                    name,
                                    release_date,
                                    artist_id,
                                    created_at)
                                VALUES
                                   (
                                     @name,
                                     @release_date,
                                     @artist_id,
                                     @created_at 
                                   ) RETURNING id;";

            var result = await ExecuteQueryFirstOrDefaultAsync<int>(query, new
            {
                name = album.Name,
                release_date = album.RelaseDate,
                artist_id = album.ArtistId,
                created_at = album.CreatedAt
            }).ConfigureAwait(false);

            return result != null;
        }
    }
}