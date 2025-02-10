using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.Entities.Artists;

namespace IAlbumDB.Infrastructure.Extensions
{
    public static class ArtistMappingExtensions
    {
        public static ArtistDetails ToDetailedDto(this ArtistEntity artist)
        {
            return new ArtistDetails
            {
                Id = artist.Id,
                Name = artist.Name,
                Albums = artist.Albums.Select(_ => _.ToBaseDto()).ToList(),
                UpdatedAt = artist.UpdatedAt
            };
        }

        public static ArtistBase ToBaseDto(this ArtistEntity artist)
        {
            return new ArtistBase
            {
                Id = artist.Id,
                Name = artist.Name,
                Members = artist.Musicians
            };
        }
    }
}
