using IAlbumDB.Domain.DTOs.Songs;

namespace IAlbumDB.Domain.DTOs.Albums
{
    public class AlbumDetailsDto : AlbumReturnDto
    {
        public string ArtistName { get; set; }
        public IList<SongReturnDto> Songs { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
