using IAlbumDB.Domain.Entities;
using IAlbumDB.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IAlbumDB.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            // set() returns the set of a given entity type
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        // No thrown exception for null lookups that is left to the client to decide if exception or not
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<Guid> AddEntityAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Guid> UpdateEntityAsync(TEntity entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        // Implementation for a hard delete. Soft deletes where is active is set to false are handled via an update
        public async Task DeleteByIdAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
