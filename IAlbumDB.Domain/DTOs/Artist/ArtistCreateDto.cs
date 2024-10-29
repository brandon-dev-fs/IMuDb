namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public IList<string>? Members { get; set; }
    }
}
