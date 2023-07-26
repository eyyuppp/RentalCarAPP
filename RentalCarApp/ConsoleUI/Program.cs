
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyCarContext();
            context.Database.EnsureCreated();


            /*
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car()
            {
                BrandID = 1,
                ColorID = 1,
                ModelYear = 2010,
                UnitPrice =10000000

            }) ;
            


            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(
                new Brand()
                {
                    BrandName="BMW"
                });

            brandManager.Add(
               new Brand()
               {
                   BrandName = "TOROS"
               });

            

            CalorManager calorManager = new CalorManager(new EfColorDal());

            calorManager.Add(new Color()
            {
                ColorName = "Black",
            });
            calorManager.Add(new Color()
            {
                ColorName = "red",
            });
            calorManager.Add(new Color()
            {
                ColorName = "Blue",
            });
         */

            
             
           


            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }
}