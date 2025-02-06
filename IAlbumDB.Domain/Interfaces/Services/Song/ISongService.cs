using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.Interfaces.Services.Song
{
    public interface ISongService
    {
        Task<IList<SongReturn>?> GetAllSongsAsync();
        Task<IList<SongReturn>?> GetAllSongsByAlbumAsync(Guid albumId);
        Task<SongDetails> GetSongByIdAsync(Guid id);
        //Task<Guid> CreateSongAsync(SongDetailsDto data);
        Task UpdateSongAsync(SongUpdate data);
        //Task DeleteSongAsync(Guid id);
    }
}
