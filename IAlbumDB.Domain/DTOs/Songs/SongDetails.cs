using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;

namespace IAlbumDB.Domain.DTOs.Songs
{
    public class SongDetails : SongReturn
    {

        public string Genre { get; init; }
        public string Lyrics { get; init; }
        public AlbumReturn Album { get; init; }
        public ArtistReturn Artist { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
