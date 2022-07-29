using Models.Entities;
using Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRepository<TEntity> : IAutoDependencyRepository where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity FindById(Guid id);
        
        

        bool Delete(TEntity entity);


        bool Create(TEntity entity);

        bool Update(TEntity entity);
    }
}
