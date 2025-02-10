using IAlbumDB.Domain.DTOs.Return.Songs;

namespace IAlbumDB.Domain.DTOs.Return.Albums
{
    public class AlbumDetails : AlbumBase
    {
        public IList<SongBase> Songs { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
