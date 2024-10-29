using IAlbumDB.Domain.DTOs.Albums;
using IAlbumDB.Domain.DTOs.Artist;

namespace IAlbumDB.Domain.DTOs.Songs
{
    public class SongDetailsDto : SongReturnDto
    {

        public string Genre { get; set; }
        public string Lyrics { get; set; }
        public AlbumReturnDto Album { get; set; }
        public ArtistReturnDto Artist { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
