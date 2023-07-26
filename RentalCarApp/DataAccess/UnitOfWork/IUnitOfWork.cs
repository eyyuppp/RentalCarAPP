using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    //IDisposable implement ediyoruz
    public interface IUnitOfWork : IDisposable
    {
        //tek bir genericRepository kullanarak add,delete ...  işlemlerini kullanmak için,
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Save();
    }
}
