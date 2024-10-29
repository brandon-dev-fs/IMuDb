using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;
using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;

namespace IAlbumDB.Infrastructure.Mappers.Song
{
    public class SongDetailsMappings : IMapping<SongDetailsDto, SongEntity>
    {
        private readonly IMapping<ArtistDetailsDto, ArtistEntity> _artistMapping;
        private readonly IMapping<AlbumDetailsDto, AlbumEntity> _albumMapping;

        public SongDetailsMappings(IMapping<ArtistDetailsDto, ArtistEntity> artistMapping, IMapping<AlbumDetailsDto, AlbumEntity> albumMapping)
        {
            _artistMapping = artistMapping;
            _albumMapping = albumMapping;
        }

        public SongDetailsDto MapToDto(SongEntity entity)
        {
            return new SongDetailsDto
            {
                Name = entity.Name,
                Length = entity.Length,
                Track = entity.Track,
                Artist = _artistMapping.MapToDto(entity.Artist),
                Album = _albumMapping.MapToDto(entity.Album),
                Genre = entity.Genre ?? string.Empty,
                Lyrics = entity.Lyrics ?? string.Empty,
                UpdatedAt = entity.UpdatedAt,
            };
        }

        public SongEntity MapToEntity(SongDetailsDto Dto)
        {
            return new SongEntity
            {
                Name = Dto.Name,
                Length = Dto.Length,
                Track = Dto.Track,
                Genre = Dto.Genre,
                Lyrics = Dto.Lyrics,
                UpdatedAt = Dto.UpdatedAt,
            };
        }
    }
}
