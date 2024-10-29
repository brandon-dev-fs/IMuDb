namespace IAlbumDB.Domain.DTOs.Artist
{
    public class ArtistReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IList<string>? Members { get; set; }
    }
}
