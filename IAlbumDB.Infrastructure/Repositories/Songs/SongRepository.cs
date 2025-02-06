using IAlbumDB.Domain.Entities.Songs;
using IAlbumDB.Domain.Interfaces.Repositories.Songs;
using Microsoft.EntityFrameworkCore;

namespace IAlbumDB.Infrastructure.Repositories.Songs
{
    public class SongRepository : GenericRepository<SongEntity>, ISongRepository
    {
        public SongRepository(DataContext context) : base(context) { }

        public async Task<SongEntity?> GetSongDetailsByIdAsync(Guid Id)
        {
            return await _context.Songs.Where(s => s.Id == Id).Include(s => s.Album).Include(s => s.Artist).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IList<SongEntity>?> GetSongsByAlbumAsync(Guid albumId)
        {
            return await _context.Songs.Where(s => s.Album.Id == albumId).AsNoTracking().ToListAsync();
        }
    }
}
