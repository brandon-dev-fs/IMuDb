using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;

namespace IAlbumDB.Domain.Entities.Songs
{
    public class SongEntity : BaseEntity
    {
        public int Length { get; set; }
        public int Track { get; set; }
        public string? Genre { get; set; }
        public AlbumEntity? Album { get; set; }
        //[ForeignKey(nameof(AlbumEntity))]
        public Guid? AlbumId { get; set; }
        public ArtistEntity? Artist { get; set; }
        //[ForeignKey(nameof(ArtistEntity))]
        public Guid? ArtistId { get; set; }
        public string? Lyrics { get; set; }
    }
}