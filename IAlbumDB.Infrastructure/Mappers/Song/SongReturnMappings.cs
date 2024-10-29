using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Song
{
    public class SongReturnMappings : IMapping<SongReturnDto, SongEntity>
    {
        public SongReturnMappings() { }

        public SongReturnDto MapToDto(SongEntity entity)
        {
            return new SongReturnDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Length = entity.Length,
                Track = entity.Track,
            };
        }

        public SongEntity MapToEntity(SongReturnDto Dto)
        {
            return new SongEntity
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Length = Dto.Length,
                Track = Dto.Track
            };
        }
    }
}
