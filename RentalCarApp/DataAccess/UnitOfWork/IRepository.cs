
using Core.Entities;
using DataAccess;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class 
    
    {
        MyCarContext GetContext();
        void Update(TEntity entity);
        List<TEntity> GetAll();
        void Delete(TEntity entity);
        void Add(TEntity entity);
        TEntity GetById(int id);
        void AddCarColor(AddCarColor addCarColor);

    }
}
