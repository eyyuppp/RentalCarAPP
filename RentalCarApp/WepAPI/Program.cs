
using Azure.Core;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.ConstrainedExecution;

namespace WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Veri taban�nda Tablo yok ise tabloyu olu�turur
            //var dbContext = new MyCarContext();
            //dbContext.Database.EnsureCreated();


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();



            //kendimiz ekliyoruz(ICarService hangi manager ile �al���ca��n� bilmiyor!,IcarDal hangi dal ile �al��aca��n� bilmiyor)


            //AddSingleton:Projemiz ilk �al��t�rd���m�z s�rada, servisin tek bir instance��n�(Nesne) olu�turularak
            // AddScoped: Gelen her bir web requesti i�in bir instance olu�turur.
            //AddTransient: Her nesne �a�r�s�nda yeni bir instance.

            builder.Services.AddSingleton<IBrandService, BrandManager>();
            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<IColorService, ColorManager>();
            builder.Services.AddSingleton<IUserService, UserManager>();

            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

            builder.Services.AddSingleton(new MyCarContext());






            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}