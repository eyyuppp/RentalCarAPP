using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Unit Of Work Design Pattern Nedir? (kurumsal bir tasarım kalıbı)

Unit Of Work tasarım deseni, yazılım uygulamamızda veritabanıyla ilgili her bir aksiyonun anlık olarak veritabanına
yansıtılmasını engelleyen ve buna nazaran tüm aksiyonları biriktirip ,bir bütün olarak bir defada tek bir connection 
üzerinden gerçekleştirilmesini sağlayan ve böylece veritabanı maliyetlerini oldukça minimize eden bir tasarım desenidir.
*/
namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        MyCarContext _context;
        public UnitOfWork(MyCarContext context)
        {
           _context = context;
        }
       
       
        //kayıt başarılı ise =1 değilse sıfırdır
        public int Save()
        {
            //kayıt olduysa 0 dan büyük int değer döndür
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            //belekten atmak
            _context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class 
        {
            //veri tabanı işlemlerini burdan yönetimini sağlar
            var repository = new Repository<TEntity>(_context);
            return repository;
        }
    }
}
