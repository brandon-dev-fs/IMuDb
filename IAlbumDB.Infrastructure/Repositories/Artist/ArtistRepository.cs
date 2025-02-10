using IAlbumDB.Domain.Entities.Albums;
using IAlbumDB.Domain.Entities.Artists;
using IAlbumDB.Domain.Interfaces.Repositories.Artist;
using Microsoft.EntityFrameworkCore;

namespace IAlbumDB.Infrastructure.Repositories.Artists
{
    public class ArtistRepository : GenericRepository<ArtistEntity>, IArtistRepository
    {
        public ArtistRepository(DataContext context) : base(context) { }

        public async Task<IList<ArtistEntity>?> GetAllArtistAsync()
        {
            return await _context.Artists.Include(ar => ar.Albums).AsNoTracking().ToListAsync();
        }

        public async Task<ArtistEntity?> GetArtistByIdAsync(Guid Id)
        {
            var returnArtist = await _context.Artists.Where(ar => ar.Id == Id).Include(ar => ar.Albums.OrderBy(al => al.Year)).AsNoTracking().FirstOrDefaultAsync();

            foreach (AlbumEntity album in returnArtist.Albums)
            {
                album.Songs = _context.Songs.Where(s => s.Album.Id == album.Id).OrderBy(s => s.Track).ToList();
            }

            return returnArtist;
        }

        public async Task<ArtistEntity?> FindArtistByNameAsync(string name)
        {
            return await _context.Artists.Where(a => a.Name == name).AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
