using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Artist
{
    public class ArtistReturnMappings : IMapping<ArtistReturnDto, ArtistEntity>
    {
        public ArtistReturnMappings() { }

        public ArtistReturnDto MapToDto(ArtistEntity entity)
        {
            return new ArtistReturnDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Members = entity.Members
            };
        }

        public ArtistEntity MapToEntity(ArtistReturnDto Dto)
        {
            return new ArtistEntity
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Members = Dto.Members?.ToList()
            };
        }
    }
}
