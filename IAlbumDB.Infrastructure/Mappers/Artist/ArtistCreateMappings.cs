using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Artist
{
    public class ArtistCreateMappings : IMapping<ArtistCreateDto, ArtistEntity>
    {
        public ArtistCreateMappings() { }

        public ArtistCreateDto MapToDto(ArtistEntity entity)
        {
            return new ArtistCreateDto
            {
                Name = entity.Name,
                Members = entity.Members
            };
        }

        public ArtistEntity MapToEntity(ArtistCreateDto Dto)
        {
            return new ArtistEntity
            {
                Name = Dto.Name,
                Members = Dto.Members?.ToList()
            };
        }
    }
}
