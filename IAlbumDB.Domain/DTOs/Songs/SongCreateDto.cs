namespace IAlbumDB.Domain.DTOs.Songs
{
    public class SongCreateDto
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Track { get; set; }
        public string Genre { get; set; }
        public string Lyrics { get; set; }
    }
}
