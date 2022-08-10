using SpotifyApplication.Converters.Artists;
using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;
using SpotifyApplication.Repositories.Albums.Interfaces;
using SpotifyApplication.Repositories.Artists.Interfaces;
using SpotifyApplication.Services.Artists.Interfaces;

namespace SpotifyApplication.Services.Artists.Implementations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;

        public ArtistService(IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }
        public List<ArtistResponse> GetArtistList(string artistId)
        {
            
             var result = new List<ArtistResponse>();
            // var artistResponse = new ArtistResponse()
            // {
            //     AlbumCount = 20,
            //     ArtistCount = 50,
            //     ArtistName = artistId,
            // };
            // result.Add(artistResponse);
             return result;
        }

        public async Task<ArtistResponse?> GetArtistById(int artistId)
        {
            var artist = await _artistRepository.GetArtistById(artistId);
            var album = await _albumRepository.GetAlbumByArtistId(artistId);
            return artist.ToArtistByIdResponse(album);
        }

        public async Task<bool> CreateArtist(CreateArtistRequest request)
        {
            var artist = request.ToArtist();
            var result = await _artistRepository.CreateArtist(artist);
            return result;
        }

        
    }
}
