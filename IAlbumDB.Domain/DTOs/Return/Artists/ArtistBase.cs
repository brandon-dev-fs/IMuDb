using IAlbumDB.Domain.Entities.Artists;

namespace IAlbumDB.Domain.DTOs.Return.Artists
{
    public class ArtistBase : BaseReturnDto
    {
        public IList<string>? Musicians { get; init; }
        public ArtistType Type { get; init; }
    }
}
