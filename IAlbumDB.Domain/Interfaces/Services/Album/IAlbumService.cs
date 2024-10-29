using IAlbumDB.Domain.DTOs.Albums;

namespace IAlbumDB.Domain.Interfaces.Services.Album
{
    public interface IAlbumService
    {
        Task<IList<AlbumReturnDto>?> GetAllAlbumsAsync();
        Task<IList<AlbumReturnDto>?> GetAllAlbumsByArtistAsync(Guid artistId);
        Task<AlbumDetailsDto> GetAlbumByIdAsync(Guid id);
        Task<Guid> CreateAlbumAsync(AlbumCreateDto album);
        Task UpdateAlbumAsync(AlbumUpdateDto album);
        Task DeleteAlbumAsync(Guid id);
    }
}
