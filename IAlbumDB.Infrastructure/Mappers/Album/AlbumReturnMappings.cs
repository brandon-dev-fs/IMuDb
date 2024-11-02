using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Album
{
    /// <summary>
    /// Maps Album Entity to basic albumReturnDto Type for a lightweight album return
    /// </summary>
    public class AlbumReturnMappings : IMapping<AlbumReturnDto, AlbumEntity>
    {
        private readonly IMapping<SongReturnDto, SongEntity> _songMapping;
        private readonly IMapping<ArtistReturnDto, ArtistEntity> _artistMapping;

        public AlbumReturnMappings(IMapping<SongReturnDto, SongEntity> songMapping, IMapping<ArtistReturnDto, ArtistEntity> artistMapping)
        {
            _songMapping = songMapping;
            _artistMapping = artistMapping;
        }

        public AlbumReturnDto MapToDto(AlbumEntity entity)
        {
            return new AlbumReturnDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Year = entity.Year
            };
        }

        public AlbumEntity MapToEntity(AlbumReturnDto Dto)
        {
            return new AlbumEntity
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Year = Dto.Year
            };
        }
    }
}
