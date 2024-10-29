namespace IAlbumDB.Domain.DTOs.Songs
{
    public class SongReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Track { get; set; }
    }
}
