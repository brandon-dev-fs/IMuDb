using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Interfaces.Repositories.Albums;
using Microsoft.EntityFrameworkCore;

namespace IAlbumDB.Infrastructure.Repositories.Albums
{
    public class AlbumRepository : GenericRepository<AlbumEntity>, IAlbumRepository
    {
        public AlbumRepository(DataContext context) : base(context) { }

        public async Task<IList<AlbumEntity>?> GetAllAlbumsAsync()
        {
            return await _context.Albums.Include(a => a.Artist).Include(a => a.Songs.OrderBy(s => s.Track)).AsNoTracking().ToListAsync();
        }

        public async Task<IList<AlbumEntity>?> GetAllByArtistAsync(Guid artistId)
        {
            return await _context.Albums.Where(al => al.Artist.Id == artistId).Include(a => a.Artist).Include(a => a.Songs.OrderBy(s => s.Track)).AsNoTracking().ToListAsync();
        }

        public async Task<AlbumEntity?> GetAlbumByIdAsync(Guid id)
        {
            return await _context.Albums.Where(al => al.Id == id).Include(a => a.Artist).Include(a => a.Songs.OrderBy(s => s.Track)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<AlbumEntity?> GetAlbumByNameAndArtistAsync(string name, Guid artistId)
        {
            return await _context.Albums.Where(al => al.Artist.Id == artistId && al.Name == name).Include(a => a.Songs.OrderBy(s => s.Track)).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
