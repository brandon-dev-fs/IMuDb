namespace IAlbumDB.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
