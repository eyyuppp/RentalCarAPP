using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace DataAccess.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected  MyCarContext _context;
        //DbSet veritabanı tablosu için kullanılır
        protected DbSet<TEntity> table;

        public Repository(MyCarContext context)
        {
            _context = context;
            table=_context.Set<TEntity>();
        }
       

        public void Add(TEntity entity)
        {
            table.Add(entity); 
        }

        public void AddCarColor(AddCarColor addCarColor)
        {
            _context.Set<Car>().Add(addCarColor.Car);
            _context.Set<Color>().Add(addCarColor.Color);
        }

        public void Delete(TEntity entity)
        {
            table.Remove(entity);
        }
        public List<TEntity> GetAll()
        {
            return table.ToList();
        }

        public void GetBrandId(int carId, int brandId)
        {
           object car=table.Find(carId);
            object brand = table.Find(brandId);

            table.Remove(GetById(carId));
            table.Remove(GetById(brandId));
        }

        public TEntity GetById(int id)
        {
           return  table.Find(id);
        }

        public MyCarContext GetContext()
        {
            return _context;
        }


        public void Update(TEntity entity)
        {
            //günceme işlemine dikkat et
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
