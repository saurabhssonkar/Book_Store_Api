using System.Collections.Generic;

namespace BookStore.Models.Repository
{
    public interface IDataRepository<TEntity, TDto>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
        // void Update(Author authorToUpdate, Author_CustomModel author);
        // void Update1(Author authorToUpdate, Author_CustomModel author);

    }
}
