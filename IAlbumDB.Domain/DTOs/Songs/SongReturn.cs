namespace IAlbumDB.Domain.DTOs.Songs
{
    public class SongReturn
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Length { get; init; }
        public int Track { get; init; }
    }
}
