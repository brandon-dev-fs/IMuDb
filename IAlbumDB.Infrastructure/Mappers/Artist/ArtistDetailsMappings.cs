using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Artist
{
    public class ArtistDetailsMappings : IMapping<ArtistDetailsDto, ArtistEntity>
    {
        private readonly IMapping<AlbumReturnDto, AlbumEntity> _albumMapping;

        public ArtistDetailsMappings(IMapping<AlbumReturnDto, AlbumEntity> albumMapping)
        {
            _albumMapping = albumMapping;
        }

        public ArtistDetailsDto MapToDto(ArtistEntity entity)
        {
            return new ArtistDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Members = entity.Members,
                Albums = entity.Albums.Select(_albumMapping.MapToDto).ToList(),
                UpdatedAt = entity.UpdatedAt
            };
        }

        public ArtistEntity MapToEntity(ArtistDetailsDto Dto)
        {
            return new ArtistEntity
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Members = Dto.Members?.ToList(),
                UpdatedAt = Dto.UpdatedAt
            };
        }
    }
}
