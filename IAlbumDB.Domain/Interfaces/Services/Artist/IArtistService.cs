using IAlbumDB.Domain.DTOs.CreateUpdate.Artists;
using IAlbumDB.Domain.DTOs.Return.Artists;

namespace IAlbumDB.Domain.Interfaces.Services.Artist
{
    public interface IArtistService
    {
        Task<IList<ArtistBase>?> GetAllArtistAsync();
        Task<ArtistDetails?> GetArtistByIdAsync(Guid Id);
        Task<Guid> CreateArtistAsync(ArtistCU artist);
        Task UpdateArtistAsync(Guid Id, ArtistCU data);
        Task SoftDeleteArtistAsync(Guid Id);
    }
}
