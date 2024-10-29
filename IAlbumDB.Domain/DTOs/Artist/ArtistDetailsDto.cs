using IAlbumDB.Domain.DTOs.Albums;

namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistDetailsDto : ArtistReturnDto
    {
        public IList<AlbumReturnDto>? Albums { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
