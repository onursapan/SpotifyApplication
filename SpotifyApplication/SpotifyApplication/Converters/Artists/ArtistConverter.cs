using SpotifyApplication.Domain.Artists;
using SpotifyApplication.Dtos.Requests;

namespace SpotifyApplication.Converters.Artists;

public static class ArtistConverter
{
    public static Artist? ToArtist(this CreateArtistRequest request)
    {
        if (request == null)
            return null;

        var entity = new Artist();
        entity.Name = request.Name;
        entity.Surname = request.Surname;
        entity.CreatedAt = DateTime.Now;

        return entity;
    }
}