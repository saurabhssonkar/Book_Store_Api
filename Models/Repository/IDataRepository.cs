using System.Collections.Generic;

namespace BookStore.Models.Repository
{
    public interface IDataRepository<TEntity, TDto,CustomModel>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, CustomModel entity);
        void Delete(TEntity entity);
    }
}
