using IAlbumDB.Domain.DTOs.Artist;

namespace IAlbumDB.Domain.Interfaces.Services.Artist
{
    public interface IArtistService
    {
        Task<IList<ArtistReturn>?> GetAllArtistAsync();
        Task<ArtistDetails?> GetArtistByIdAsync(Guid id);
        Task<Guid> CreateArtistAsync(ArtistCU artist);
        Task UpdateArtistAsync(ArtistCU data);
        Task SoftDeleteArtistAsync(Guid id);
    }
}
