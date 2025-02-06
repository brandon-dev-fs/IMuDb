using IAlbumDB.Domain.DTOs.Albums;

namespace IAlbumDB.Domain.Interfaces.Services.Album
{
    public interface IAlbumService
    {
        Task<IList<AlbumReturn>?> GetAllAlbumsAsync();
        Task<IList<AlbumReturn>?> GetAllAlbumsByArtistAsync(Guid artistId);
        Task<AlbumDetails> GetAlbumByIdAsync(Guid id);
        // Start Here
        Task<Guid> CreateAlbumAsync(AlbumCreate album);
        Task UpdateAlbumAsync(AlbumUpdate album);

        Task DeleteAlbumAsync(Guid id);
    }
}
