using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SOAP isteklerinin kayıtlarını tutan, XML tabanlı web servisleri oluşturmak için tanımlanmış bir dildir.
namespace DataAccess
{
    //dbContext kalıtım alınıyor entityFrameWork ile(EntityFrameWork eklemek lazım)
    public class MyCarContext : DbContext
    {
        public string data="Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyCars;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //veri tabanına bağlanma işlenmi gerçekleşir
            optionsBuilder.UseSqlServer(data);
        }


        //Tabloda hangi class hangi sutuna denk geliceğini sağlar
       //Dbset veritabanı yönetim sistemlerinde kullanılan bir terimdir.Bir veritabanı içindeki bir veya daha fazla tabloya erişimi temsil eder
       //veri tabanımızın kolonları giriliyor
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
      //  public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //oluşturduğum modelerin veriabanında hangi table adıyla kaydedmemi sağlar
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Brand>().ToTable("Brands");

            //UserId Primary key olur
            modelBuilder.Entity<User>()
                .HasKey(x => x.UserID);

            modelBuilder.Entity<Brand>()
                .HasKey(x => x.BrandID);

            modelBuilder.Entity<Color>()
                .HasKey(x => x.ColorID);

            modelBuilder.Entity<Car>()
                .HasKey(x => x.CarID);
        }

    }



}
