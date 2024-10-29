using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.Interfaces.Services.Song
{
    public interface ISongService
    {
        Task<IList<SongReturnDto>?> GetAllSongsAsync();
        Task<IList<SongReturnDto>?> GetAllSongsByAlbumAsync(Guid albumId);
        Task<SongDetailsDto> GetSongByIdAsync(Guid id);
        //Task<Guid> CreateSongAsync(SongDetailsDto data);
        Task UpdateSongAsync(SongUpdateDto data);
        //Task DeleteSongAsync(Guid id);
    }
}
