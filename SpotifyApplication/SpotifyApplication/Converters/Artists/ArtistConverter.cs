using System.Runtime.CompilerServices;
using SpotifyApplication.Domain.Albums;
using SpotifyApplication.Domain.Artists;
using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;

namespace SpotifyApplication.Converters.Artists;

public static class ArtistConverter
{
    
    public static ArtistResponse? ToArtistByIdResponse(this Artist entity, IEnumerable<Album> albums)
    {
        if (entity == null)
            return null;

        var albumNameList = new List<string>();
        foreach (var album in albums)
        {
            albumNameList.Add(album.Name);
        }
        
        var response = new ArtistResponse()
        {
            Name = entity.Name,
            Surname = entity.Surname,
            AlbumNames = albumNameList // Foreach yapısı ile albumNameList ile veri çektik.
            //AlbumName = albums?.Select(s => s.Name).ToList(), Linq kullanarak listeden veri seçtik.
        };
        
        return response;
    }
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