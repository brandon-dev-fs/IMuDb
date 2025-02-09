using IAlbumDB.Domain.DTOs.Return.Artists;

namespace IAlbumDB.Domain.DTOs.Return.Albums
{
    public class AlbumBase : BaseReturnDto
    {
        public int Year { get; init; }
        public ArtistBase Artist { get; init; }
    }
}
