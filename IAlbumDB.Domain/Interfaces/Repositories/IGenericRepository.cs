namespace IAlbumDB.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid Id);
        Task<Guid> AddEntityAsync(TEntity entity);
        Task<Guid> UpdateEntityAsync(TEntity entity);
        Task DeleteByIdAsync(TEntity entity);
    }
}
