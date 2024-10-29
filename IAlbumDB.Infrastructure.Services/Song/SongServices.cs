using IAlbumDB.Domain.DTOs.Songs;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Domain.Interfaces.Repositories.Songs;
using IAlbumDB.Domain.Interfaces.Services.Song;

namespace IAlbumDB.Infrastructure.Services.Song
{
    public class SongServices : ISongService
    {
        protected readonly ISongRepository _songRepository;
        private readonly IMapping<SongDetailsDto, SongEntity> _songDetailsMapping;
        private readonly IMapping<SongReturnDto, SongEntity> _songReturnMapping;

        public SongServices(ISongRepository songRepository,
            IMapping<SongDetailsDto, SongEntity> songDetailsMapping,
            IMapping<SongReturnDto, SongEntity> songReturnMapping)
        {
            _songRepository = songRepository;
            _songDetailsMapping = songDetailsMapping;
            _songReturnMapping = songReturnMapping;
        }

        public async Task<IList<SongReturnDto>?> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetAllAsync();
            var formattedSongs = songs.Select(_songReturnMapping.MapToDto).ToList();
            return formattedSongs;
        }

        public async Task<IList<SongReturnDto>?> GetAllSongsByAlbumAsync(Guid albumId)
        {
            var songs = await _songRepository.GetSongsByAlbumAsync(albumId);
            var formattedSongs = songs?.Select(_songReturnMapping.MapToDto).ToList();
            return formattedSongs;
        }

        public async Task<SongDetailsDto> GetSongByIdAsync(Guid id)
        {
            var song = await _songRepository.GetByIdAsync(id);

            if (song == null)
            {
                throw new Exception("Song could not be found with id");
            }

            return _songDetailsMapping.MapToDto(song);
        }

        // Create removed as songs are created at album creation
        //public async Task<Guid> CreateSongAsync(SongCreateDto data)
        //{
        //    SongEntity newSong = _songMapping.MapToEntity(data);
        //    newSong.Id = Guid.NewGuid();
        //    newSong.IsActive = true;
        //    newSong.CreatedAt = DateTime.UtcNow;
        //    newSong.UpdatedAt = DateTime.UtcNow;

        //    await _songRepository.AddEntityAsync(newSong);

        //    return newSong.Id;
        //}

        /// <summary>
        /// Song update only allows for lyric updates
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSongAsync(SongUpdateDto data)
        {
            var updateSong = await _songRepository.GetByIdAsync(data.ID);

            if (updateSong == null)
            {
                throw new Exception("Song could not be found with id");
            }

            updateSong.Lyrics = data.Lyrics;
            updateSong.UpdatedAt = DateTime.UtcNow;

            await _songRepository.UpdateEntityAsync(updateSong);
        }

        // Delete removed as songs are deleted at album deletion
        //public async Task DeleteSongAsync(Guid id)
        //{
        //    var deleteSong = await _songRepository.GetByIdAsync(id);

        //    if (deleteSong == null)
        //    {
        //        throw new Exception("Song could not be found with id");
        //    }

        //    deleteSong.IsActive = false;
        //    deleteSong.UpdatedAt = DateTime.UtcNow;

        //    await _songRepository.UpdateEntityAsync(deleteSong);
        //}
    }
}
