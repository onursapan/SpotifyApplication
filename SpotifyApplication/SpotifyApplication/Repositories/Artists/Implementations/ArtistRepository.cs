using SpotifyApplication.Domain.Artists;
using SpotifyApplication.Repositories.Artists.Interfaces;
using SpotifyApplication.Repositories.Base;

namespace SpotifyApplication.Repositories.Artists.Implementations;

public class ArtistRepository: BaseRepository, IArtistRepository
{
    public ArtistRepository(IConfiguration config) : base(config)
    {
    }
    public Task<IEnumerable<Artist>> GetArtistList()
    {
        throw new NotImplementedException();
    }

    public async Task<Artist> GetArtistById(int artistId)
    {
        const string query = @"SELECT * FROM artist WHERE id = @artistId";
        return await ExecuteQueryFirstOrDefaultAsync<Artist>(query, new {artistId}).ConfigureAwait(false);
    }

    public async Task<bool> CreateArtist(Artist artist)
    {
        const string query = @"INSERT INTO artist
                                   ( 
                                    name,
                                    surname,
                                    created_at
                                    )
                                VALUES
                                   (
                                     @name,
                                     @surname,
                                     @created_at 
                                   ) RETURNING id;";

       var result = await ExecuteQueryFirstOrDefaultAsync<int>(query, new
        {
            name = artist.Name,
            surname = artist.Surname,
            created_at = artist.CreatedAt
        }).ConfigureAwait(false);

        return result != null;
    }
}