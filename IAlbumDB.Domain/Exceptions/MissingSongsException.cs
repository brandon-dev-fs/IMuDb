namespace IAlbumDB.Domain.Exceptions
{
    public class MissingSongsException : Exception
    {
        public MissingSongsException() { }

        public MissingSongsException(string message) : base(message) { }
    }
}
