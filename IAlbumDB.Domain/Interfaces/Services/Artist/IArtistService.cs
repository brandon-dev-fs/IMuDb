using IAlbumDB.Domain.DTOs.Artist;

namespace IAlbumDB.Domain.Interfaces.Services.Artist
{
    public interface IArtistService
    {
        Task<IList<ArtistReturnDto>?> GetAllArtistAsync();
        Task<ArtistDetailsDto?> GetArtistByIdAsync(Guid id);
        Task<Guid> CreateArtistAsync(ArtistCreateDto artist);
        Task UpdateArtistAsync(ArtistUpdateDto data);
        Task DeleteArtistAsync(Guid id);
    }
}
