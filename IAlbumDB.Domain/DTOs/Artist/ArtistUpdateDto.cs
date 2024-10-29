namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistUpdateDto
    {
        public Guid Id { get; set; }
        public IList<string>? Members { get; set; }
    }
}
