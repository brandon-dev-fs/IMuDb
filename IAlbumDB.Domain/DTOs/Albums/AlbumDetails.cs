using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumDetails : AlbumReturn
    {
        public string ArtistName { get; init; }
        public IList<SongReturn> Songs { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
