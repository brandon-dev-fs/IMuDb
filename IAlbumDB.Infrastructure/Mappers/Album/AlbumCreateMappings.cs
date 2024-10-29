using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Album
{
    public class AlbumCreateMappings : IMapping<AlbumCreateDto, AlbumEntity>
    {
        private readonly IMapping<SongCreateDto, SongEntity> _songMapping;

        public AlbumCreateMappings(IMapping<SongCreateDto, SongEntity> songMapping)
        {
            _songMapping = songMapping;
        }

        public AlbumCreateDto MapToDto(AlbumEntity entity)
        {
            return new AlbumCreateDto
            {
                Name = entity.Name,
                Year = entity.Year,
                ArtistId = entity.ArtistId,
                Songs = entity.Songs.Select(_songMapping.MapToDto).ToList(),
            };
        }

        public AlbumEntity MapToEntity(AlbumCreateDto Dto)
        {
            return new AlbumEntity
            {
                Name = Dto.Name,
                Year = Dto.Year,
                ArtistId = Dto.ArtistId,
                Songs = Dto.Songs.Select(_songMapping.MapToEntity).ToList(),
            };
        }
    }
}
