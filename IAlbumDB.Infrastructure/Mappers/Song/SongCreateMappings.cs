using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Song
{
    public class SongCreateMappings : IMapping<SongCreateDto, SongEntity>
    {
        public SongCreateMappings() { }

        public SongCreateDto MapToDto(SongEntity entity)
        {
            return new SongCreateDto
            {
                Name = entity.Name,
                Length = entity.Length,
                Track = entity.Track,
                Genre = entity.Genre ?? string.Empty,
                Lyrics = entity.Lyrics ?? string.Empty
            };
        }

        public SongEntity MapToEntity(SongCreateDto Dto)
        {
            return new SongEntity
            {
                Name = Dto.Name,
                Length = Dto.Length,
                Track = Dto.Track,
                Genre = Dto.Genre,
                Lyrics = Dto.Lyrics,
            };
        }
    }
}
