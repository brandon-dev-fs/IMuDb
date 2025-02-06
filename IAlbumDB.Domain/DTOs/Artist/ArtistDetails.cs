using IAlbumDB.Domain.DTOs.Albums;

namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistDetails : ArtistReturn
    {
        public IList<AlbumReturn>? Albums { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
