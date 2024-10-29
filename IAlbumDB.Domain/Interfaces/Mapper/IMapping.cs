namespace IAlbumDB.Domain.Interfaces.Mapper
{
    public interface IMapping<TDto, TEntity>
    {
        TDto MapToDto(TEntity entity);
        TEntity MapToEntity(TDto Dto);
    }
}
