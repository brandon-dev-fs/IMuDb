
using IAlbumDB.Domain.DTOs.CreateUpdate.Songs;
using IAlbumDB.Domain.DTOs.Return.Songs;

namespace IAlbumDB.Domain.Interfaces.Services.Song
{
    public interface ISongService
    {
        Task<IList<SongBase>?> GetAllSongsAsync();
        Task<IList<SongBase>?> GetAllSongsByAlbumAsync(Guid albumId);
        Task<SongDetails> GetSongByIdAsync(Guid Id);
        Task UpdateSongAsync(Guid Id, SongCU data);
    }
}
