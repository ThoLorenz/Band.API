using System;
using System.Collections.Generic;

namespace Band.API.Models.Repository
    {
    public interface IDataRepository<TEntity, U> where TEntity : class
        {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        int Add(TEntity b);
        int Update(U id, TEntity b);
        int Delete(U id);
        }
    }
