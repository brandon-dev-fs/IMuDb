namespace IAlbumDB.Domain.Interfaces.Mapper
{
    //public interface IMapping<TDto, TEntity>
    //{
    //    TDto Map(TEntity entity);
    //    TEntity MapToEntity(TDto Dto);
    //}

    public interface IMapping<out TOut, in TIn>
    {
        TOut Map(TIn input);
    }
}
