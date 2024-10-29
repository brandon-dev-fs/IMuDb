using IAlbumDB.Domain.Entities.Songs;

namespace IAlbumDB.Domain.Interfaces.Repositories.Songs
{
    public interface ISongRepository : IGenericRepository<SongEntity>
    {
        Task<SongEntity?> GetSongDetailsByIdAsync(Guid Id);
        Task<IList<SongEntity>?> GetSongsByAlbumAsync(Guid albumId);
    }
}
