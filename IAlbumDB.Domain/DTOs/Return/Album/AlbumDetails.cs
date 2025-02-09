using IAlbumDB.Domain.DTOs.Return.Artists;
using IAlbumDB.Domain.DTOs.Return.Songs;

namespace IAlbumDB.Domain.DTOs.Return.Albums
{
    public class AlbumDetails : AlbumBase
    {
        public ArtistBase Artist { get; init; }
        public IList<SongBase> Songs { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
