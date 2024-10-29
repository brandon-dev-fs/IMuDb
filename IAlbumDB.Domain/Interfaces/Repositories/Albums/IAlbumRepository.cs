using IAlbumDB.Domain.Entities.Albums;

namespace IAlbumDB.Domain.Interfaces.Repositories.Albums
{
    public interface IAlbumRepository : IGenericRepository<AlbumEntity>
    {
        Task<IList<AlbumEntity>?> GetAllAlbumsAsync();
        Task<IList<AlbumEntity>?> GetAllByArtistAsync(Guid artistId);
        Task<AlbumEntity?> GetAlbumByIdAsync(Guid id);
        Task<AlbumEntity?> GetAlbumByNameAndArtistAsync(string name, Guid artistId);
    }
}
