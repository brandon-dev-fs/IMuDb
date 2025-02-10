using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Songs;
using IAlbumDB.Domain.Interfaces.Repositories.Songs;
using IAlbumDB.Domain.Interfaces.Services.Song;
using IAlbumDB.Infrastructure.Extensions;

namespace IAlbumDB.Infrastructure.Services.Song
{
    public class SongServices : ISongService
    {
        protected readonly ISongRepository _songRepository;

        public SongServices(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<IList<SongBase>?> GetAllSongsAsync()
        {
            var songs = await _songRepository.GetAllAsync();
            var formattedSongs = songs.Select(_ => _.ToBaseDto()).ToList();
            return formattedSongs;
        }

        public async Task<IList<SongBase>?> GetAllSongsByAlbumAsync(Guid albumId)
        {
            var songs = await _songRepository.GetSongsByAlbumAsync(albumId);
            var formattedSongs = songs?.Select(_ => _.ToBaseDto()).ToList();
            return formattedSongs;
        }

        public async Task<SongDetails> GetSongByIdAsync(Guid Id)
        {
            var song = await _songRepository.GetSongDetailsByIdAsync(Id);

            if (song == null)
            {
                throw new Exception($"Song could not be found with {Id}");
            }

            return song.ToDetailedDto();
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
