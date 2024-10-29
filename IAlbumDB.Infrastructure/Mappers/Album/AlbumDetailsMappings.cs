using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Album
{

    public class AlbumDetailsMappings : IMapping<AlbumDetailsDto, AlbumEntity>
    {
        private readonly IMapping<SongReturnDto, SongEntity> _songMapping;
        private readonly IMapping<ArtistReturnDto, ArtistEntity> _artistMapping;

        public AlbumDetailsMappings(IMapping<SongReturnDto, SongEntity> songMapping, IMapping<ArtistReturnDto, ArtistEntity> artistMapping)
        {
            _songMapping = songMapping;
            _artistMapping = artistMapping;
        }

        public AlbumDetailsDto MapToDto(AlbumEntity entity)
        {
            return new AlbumDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Year = entity.Year,
                ArtistName = entity.Artist.Name,
                Songs = entity.Songs.Select(_songMapping.MapToDto).ToList(),
                UpdatedAt = entity.UpdatedAt,
            };
        }

        public AlbumEntity MapToEntity(AlbumDetailsDto Dto)
        {
            return new AlbumEntity
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Year = Dto.Year,
                Songs = Dto.Songs.Select(_songMapping.MapToEntity).ToList(),
                UpdatedAt = Dto.UpdatedAt,
            };
        }
    }
}
