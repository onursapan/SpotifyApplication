using SpotifyApplication.Domain.Albums;
using SpotifyApplication.Dtos.Requests;
using SpotifyApplication.Dtos.Responses;

namespace SpotifyApplication.Converters.Albums
{
    public static class AlbumConverter
    {
        public static List<AlbumResponse>? ToAlbumResponse(this IEnumerable<Album> entities)
        {
            if (entities == null)
                return null;

            var response = new List<AlbumResponse>();

            foreach (var entity in entities)
            {
                response.Add(new AlbumResponse()
                {
                    CreatedAt = entity.CreatedAt,
                    RelaseDate = entity.RelaseDate,
                    Name = entity.Name
                });
            }

            return response;
        }

        public static AlbumResponse? ToAlbumByIdResponse(this Album entity)
        {
            if (entity == null)
                return null;

            var response = new AlbumResponse()
            {
                CreatedAt = entity.CreatedAt,
                RelaseDate = entity.RelaseDate,
                Name = entity.Name
            };


            return response;
        }

        public static Album? ToAlbum(this CreateAlbumRequest request)
        {
            if (request == null)
                return null;

            var entity = new Album();
            entity.Name = request.Name;
            entity.ArtistId = request.ArtistId;
            entity.RelaseDate = DateTime.Parse(request.RelaseDate);
            entity.CreatedAt = DateTime.Now;

            return entity;
        }
    }
}