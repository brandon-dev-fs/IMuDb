namespace IAlbumDB.Domain.DTOs.CreateUpdate.Songs
{
    public class SongCU
    {
        public string Name { get; init; }
        public int Length { get; init; }
        public int Track { get; init; }
        public string? Genre { get; init; }
        public string? Lyrics { get; init; }
    }
}
