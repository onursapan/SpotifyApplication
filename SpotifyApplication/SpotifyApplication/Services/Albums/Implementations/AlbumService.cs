using SpotifyApplication.Dtos.Responses;
using SpotifyApplication.Repositories.Albums.Interfaces;
using SpotifyApplication.Services.Albums.Interfaces;
using SpotifyApplication.Converters.Albums;
using SpotifyApplication.Dtos.Requests;

namespace SpotifyApplication.Services.Albums.Implementations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<List<AlbumResponse>?> GetAlbumList()
        {
            var result = await _albumRepository.GetAlbumList();
            return result.ToAlbumResponse();
        }

        public async Task<AlbumResponse?> GetAlbumById(int albumId)
        {
            var result = await _albumRepository.GetAlbumById(albumId);
            return result.ToAlbumByIdResponse();
        }


        public async Task<bool> CreateAlbum(CreateAlbumRequest request)
        {
            var album = request.ToAlbum();
            var result = await _albumRepository.CreateAlbum(album);
            return result;
        }
        
    }
}
