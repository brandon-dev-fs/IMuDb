using IAlbumDB.Domain.DTOs.CreateUpdate.Albums;
using IAlbumDB.Domain.DTOs.Return.Albums;

namespace IAlbumDB.Domain.Interfaces.Services.Album
{
    public interface IAlbumService
    {
        Task<IList<AlbumBase>?> GetAllAlbumsAsync();
        Task<IList<AlbumBase>?> GetAllAlbumsByArtistAsync(Guid artistId);
        Task<AlbumDetails> GetAlbumByIdAsync(Guid Id);
        // Start Here
        Task<Guid> CreateAlbumAsync(AlbumCU album);
        Task UpdateAlbumAsync(Guid Id, AlbumCU data);

        Task DeleteAlbumAsync(Guid Id);
    }
}
