using IAlbumDB.Domain.DTOs.Return.Albums;
using IAlbumDB.Domain.Entities.Albums;

namespace IAlbumDB.Infrastructure.Extensions
{
    public static class AlbumEntityExtensions
    {
        public static AlbumDetails ToDetailedDto(this AlbumEntity album)
        {
            return new AlbumDetails
            {
                Id = album.Id,
                Name = album.Name,
                Year = album.Year,
                Artist = album.Artist.ToBaseDto(),
                Songs = album.Songs.Select(_ => _.ToBaseDto()).ToList(),
            };
        }

        public static AlbumBase ToBaseDto(this AlbumEntity album)
        {
            return new AlbumBase
            {
                Id = album.Id,
                Name = album.Name,
                Year = album.Year,
                Artist = album.Artist.ToBaseDto(),
            };
        }
    }
}
