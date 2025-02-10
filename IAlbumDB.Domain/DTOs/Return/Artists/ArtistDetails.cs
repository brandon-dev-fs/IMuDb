using IAlbumDB.Domain.DTOs.Return.Albums;

namespace IAlbumDB.Domain.DTOs.Return.Artists
{
    public class ArtistDetails : ArtistBase
    {
        public IList<AlbumBase>? Albums { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
