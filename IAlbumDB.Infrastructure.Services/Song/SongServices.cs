using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Songs;
using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Mapper;
using IAlbumDB.Domain.Interfaces.Repositories.Songs;
using IAlbumDB.Domain.Interfaces.Services.Song;
using IAlbumDB.Infrastructure.Extensions;

namespace IAlbumDB.Infrastructure.Services.Song
{
    public class SongServices : ISongService
    {
        protected readonly ISongRepository _songRepository;
        private readonly IMapping<SongDetails, SongEntity> _songDetailsMapping;
        private readonly IMapping<SongBase, SongEntity> _songReturnMapping;

        public SongServices(ISongRepository songRepository,
            IMapping<SongDetails, SongEntity> songDetailsMapping,
            IMapping<SongBase, SongEntity> songReturnMapping)
        {
            _songRepository = songRepository;
            _songDetailsMapping = songDetailsMapping;
            _songReturnMapping = songReturnMapping;
        }

        public async Task<IList<SongBase>?> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetAllAsync();
            var formattedSongs = songs.Select(_songReturnMapping.Map).ToList();
            return formattedSongs;
        }

        public async Task<IList<SongBase>?> GetAllSongsByAlbumAsync(Guid albumId)
        {
            var songs = await _songRepository.GetSongsByAlbumAsync(albumId);
            var formattedSongs = songs?.Select(_songReturnMapping.Map).ToList();
            return formattedSongs;
        }

        public async Task<SongDetails> GetSongByIdAsync(Guid Id)
        {
            var song = await _songRepository.GetSongDetailsByIdAsync(Id);

            if (song == null)
            {
                throw new Exception($"Song could not be found with {Id}");
            }

            //return _songDetailsMapping.Map(song);

            return song.ToDto();
        }

        /// <summary>
        /// Song update only allows for lyric updates
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSongAsync(Guid Id, SongCU data)
        {
            var updateSong = await _songRepository.GetByIdAsync(Id);

            if (updateSong == null)
            {
                throw new Exception("Song could not be found with Id");
            }

            updateSong.Lyrics = data.Lyrics;
            updateSong.UpdatedAt = DateTime.UtcNow;

            await _songRepository.UpdateEntityAsync(updateSong);
        }
    }
}
